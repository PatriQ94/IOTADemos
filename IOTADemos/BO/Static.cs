using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IOTADemos.BO
{
    class Static
    {
        public static readonly HttpClient client = new HttpClient();
        public static Random rnd = new Random();
    }
}
