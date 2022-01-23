using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using Newtonsoft.Json;

namespace ObsBehringerVolume
{
    class Program
    {
        static protected OBSWebsocket obs;
        static void Main(string[] args)
        {
            /*obs = new OBSWebsocket();
            obs.Connected += Obs_Connected;
            obs.Connect("ws://127.0.0.1:4444", "");
            while (true)
            {
                Thread.Sleep(100);
            }*/
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
