using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTADemos.BO
{
    class Node
    {
        public string node { get; set; }
        public string health { get; set; }
        public string neighbors { get; set; }
        public string version { get; set; }
        public string milestone { get; set; }
        public string load { get; set; }
        public string pow { get; set; }
    }
}
