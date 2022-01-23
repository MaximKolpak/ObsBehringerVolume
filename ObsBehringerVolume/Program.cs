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

namespace ObsBehringerVolume
{
    class Program
    {
        static protected OBSWebsocket obs;
        static protected X32ConnectCheck x32check;
        static protected X32Console console;
        static void Main(string[] args)
        {
            x32check = new X32ConnectCheck("192.168.31.172", 10023);
            x32check.Connect += X32check_Connect;
            console = new X32Console() { IPAddress = IPAddress.Parse("192.168.31.172"), Port = 10023, Interval = 1000 };
            /*obs = new OBSWebsocket();
            obs.Connected += Obs_Connected;
            obs.Connect("ws://127.0.0.1:4444", "");
            */
            while (true)
            {
                Thread.Sleep(100);
            }
        }

        private static void X32check_Connect(object sender, bool e)
        {
            Console.WriteLine($"Connect: {e}");
        }

        private static void Obs_Connected(object sender, EventArgs e)
        {
            /*SourceTracks MainAudioTrack = obs.GetAudioTracks("main");
            VolumeInfo volume = obs.GetVolume("main");
            obs.SetVolume("main", 0);
            for (float i = 0; i <= 1; i+=0.01f)
            {
                obs.SetVolume("main", i);
                Thread.Sleep(100);
            }*/
        }
    }
}
