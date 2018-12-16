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
        public static readonly List<char> alphabet = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '9' };
        public static readonly HttpClient client = new HttpClient();
        public static Random random = new Random();
        public static string seed { get; set; }
        public static string currentNode { get; set; }
    }
}
