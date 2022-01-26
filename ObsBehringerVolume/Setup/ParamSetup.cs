using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsBehringerVolume.Setup
{
    public class ParamSetup
    {
        public string ipObs { get; set; }
        public int portObs { get; set; }
        public string passObs { get; set; }
        public string nameVolume { get; set; }
        public float obsmaxVolume { get; set; }
        public float obsminVolume { get; set; }
        public string ipMixer { get; set; }
        public int portMixer { get; set; }
        public int[] channelId { get; set; }
        public bool hideConsole { get; set; }
    }
}
