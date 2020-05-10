using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Singleton
{
    class Types
    {
        public Types(int tId, string type, string origine, string el, int zooMap)
        {
            Type = type;
            TId = tId;
            Origine = origine;
            El = el;
            ZooMap = zooMap;


        }
        public int TId { get; set; }
        public string Type { get; set; }
        public string Origine { get; set; }
        public string El { get; set; }
        public int ZooMap { get; set; }
    }
}
