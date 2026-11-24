using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer.Client.ConsumerService.ConsumeClient cc = new ConsumerService.ConsumeClient();
            string str = cc.GetData(101);   //cc.GetDataAsync(101);
            Consumer.Client.ConsumerService.ConsumerCacheManagementClient ccmc = new ConsumerService.ConsumerCacheManagementClient();
            ccmc.RefreshAll();
        }
    }
}
