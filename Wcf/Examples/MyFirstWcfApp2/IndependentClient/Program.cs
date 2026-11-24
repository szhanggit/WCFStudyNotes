using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IndependentClientService.WcfServiceClient proxy = new IndependentClientService.WcfServiceClient();
            string msg = proxy.GetData(0);
            Console.WriteLine(string.Format("The returned message is：{0}. ", msg));
            Console.ReadKey();
        }
    }
}
