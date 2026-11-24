using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.WcfServiceClient proxy = new ServiceReference1.WcfServiceClient();
            string msg = proxy.GetData(0);
            Console.WriteLine(string.Format("The returned message is：{0}. ", msg));
            Console.ReadKey();
        }
    }
}
