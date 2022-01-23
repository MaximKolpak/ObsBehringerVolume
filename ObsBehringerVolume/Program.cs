using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using Newtonsoft.Json;
using ObsBehringerVolume.Functions;
using Behringer.X32;
using System.Net;
using System.IO;
using ObsBehringerVolume.Setup;

namespace ObsBehringerVolume
{
    class Program
    {
        static ParamSetup paramSetup;

        static protected OBSWebsocket obs;
        static protected X32ConnectCheck x32check;
        static protected X32Console console;

        static bool mixerConnect = false;
        static bool obsConnect = false;

        static List<ListChannel> listChannels;
        static void Main(string[] args)
        {
            string path = CheckSetup();
            paramSetup = JsonConvert.DeserializeObject<ParamSetup>(File.ReadAllText(path));
            SetupListChannels(paramSetup);
            x32check = new X32ConnectCheck(paramSetup.ipMixer, paramSetup.portMixer);
            x32check.Connect += X32check_Connect;
            obs = new OBSWebsocket();
            obs.Connected += Obs_Connected;
            obs.Disconnected += Obs_Disconnected;
            AwaitConnectObs();
            while (true)
            {
                Thread.Sleep(100);
            }
        }

        private static void SetupListChannels(ParamSetup paramSetup)
        {
            listChannels = new List<ListChannel>();
            if (paramSetup.channelId.Length != 0)
            {
                foreach (string item in paramSetup.channelId)
                {
                    listChannels.Add(new ListChannel() { Id = item, Value = 0 });
                }
            }
        }

        private static void AwaitConnectObs()
        {
            Console.WriteLine("[OBS] AwaitConnect");
            while (!obsConnect)
            {
                obs.Connect($"ws://{paramSetup.ipObs}:{paramSetup.portObs}", paramSetup.passObs);
                Thread.Sleep(5000);
            }
        }


        private static void X32check_Connect(object sender, bool e)
        {
            if (!mixerConnect && e)
            {
                Console.WriteLine($"[X32] Connected");
                console = new X32Console() { IPAddress = IPAddress.Parse(paramSetup.ipMixer), Port = paramSetup.portMixer, Interval = 1000 };
                console.OnConnect += Console_OnConnect;
                console.Connect();
            }
            mixerConnect = e;
        }

        private static void Console_OnConnect()
        {
            console.OnChannelMute += Console_OnChannelMute;
        }

        private static void Console_OnChannelMute(object sender, OSC.OSCPacket packet)
        {
            string auxId = packet.Nodes[2];
            int value = packet.Arguments[0].ToInt();
            if (obsConnect && paramSetup.channelId.Length != 0)
            {
                try
                {
                    string id = paramSetup.channelId.Where(x => x == auxId).First();
                    if (id == auxId)
                        AuxMutted(id, value);
                }
                catch { }
            }
        }

        private static void AuxMutted(string id, int value)
        {
            ListChannel channel = listChannels.Where(x => x.Id == id).First();
            channel.Value = value;

            ScanChannle();
        }

        private static void ScanChannle()
        {
            int disabled = listChannels.Where(x => x.Value == 0).Count();
            int endabled = listChannels.Count - disabled;

            if (endabled != 0)
                UpVolume();
            else
                DownVolume();
        }

        private static void DownVolume()
        {
            float volume = obs.GetVolume(paramSetup.nameVolume).Volume;
            if (volume == paramSetup.obsmaxVolume)
                return;

            for (float i = volume; i >= paramSetup.obsminVolume; i -= 0.02f)
            {
                obs.SetVolume(paramSetup.nameVolume, i);
                Thread.Sleep(100);
            }
        }

        private static void UpVolume()
        {
            float volume = obs.GetVolume(paramSetup.nameVolume).Volume;
            if (volume == paramSetup.obsmaxVolume)
                return;

            for (float i = volume; i <= paramSetup.obsmaxVolume; i += 0.02f)
            {
                obs.SetVolume(paramSetup.nameVolume, i);
                Thread.Sleep(100);
            }
        }

        private static void Obs_Connected(object sender, EventArgs e)
        {
            obsConnect = true;
            Console.WriteLine("[OBS] Connected");
            obs.SetVolume(paramSetup.nameVolume, paramSetup.obsminVolume);
        }

        private static void Obs_Disconnected(object sender, EventArgs e)
        {
            obsConnect = false;
            Console.WriteLine("[OBS] Dissconected");
            AwaitConnectObs();
        }

        private static string CheckSetup()
        {
            string fileSetup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "obsbehringervolume.json");
            if (File.Exists(fileSetup))
                return fileSetup;

            ParamSetup param = new ParamSetup()
            {
                ipMixer = "127.0.0.1",
                ipObs = "127.0.0.1",
                portMixer = 10023,
                portObs = 4444,
                nameVolume = "main",
                channelId = new string[0],
                passObs = "",
                obsmaxVolume = 1f,
                obsminVolume = 0.7f
            };

            File.WriteAllText(fileSetup, JsonConvert.SerializeObject(param));
            return fileSetup;
        }
    }
}
