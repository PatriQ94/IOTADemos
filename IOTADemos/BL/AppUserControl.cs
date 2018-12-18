using IOTADemos.BO;
using IOTADemos.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangle.Net.Entity;
using Tangle.Net.Repository;

namespace IOTADemos.BL
{
    class AppUserControl
    {
        public List<string> FillNodeDropDown()
        {
            List<string> nodeList = new List<string>();

            nodeList.Add("Choose a node to connect");
            var responseString = Static.client.GetStringAsync("https://nodes.iota.works/api/ssl/live").Result;
            if (!string.IsNullOrEmpty(responseString))
            {
                List<Node> nodes = new List<Node>();
                nodes = JsonConvert.DeserializeObject<List<Node>>(responseString);
                foreach (var node in nodes)
                {
                    nodeList.Add(node.node);
                }
            }
            return nodeList;
        }

        public string SeedValidation(string seed)
        {
            if (seed.Length > Seed.Length)
            {
                seed = seed.Substring(0, Seed.Length);
            }

            if (seed.Any(l => char.IsLower(l)))
            {
                StringBuilder sb = new StringBuilder(seed);
                for (int i = 0; i < seed.Length; i++)
                {
                    if (char.IsLower(seed[i]))
                    {
                        sb[i] = char.ToUpper(seed[i]);
                    }
                }
                seed = sb.ToString();
            }

            return seed;
        }
    }
}
