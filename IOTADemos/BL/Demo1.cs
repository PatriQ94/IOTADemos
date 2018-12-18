using IOTADemos.BO;
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
    class Demo1
    {
        public static Address GetNextAvailableAddress(RestIotaRepository repository)
        {
            if (repository == null) {
                repository = new RestIotaRepository(new RestClient(Static.currentNode));
            }

            Seed seed = new Seed(Static.seed);
            for (int i = 0; i < 50; i++)
            {
                List<Address> addresses = repository.GetNewAddresses(seed, i, 1, 2);

                if (addresses != null && addresses.Count > 0 && !addresses.First().SpentFrom)
                {
                    return addresses.First();
                }
            }
            return null;
        }
    }
}
