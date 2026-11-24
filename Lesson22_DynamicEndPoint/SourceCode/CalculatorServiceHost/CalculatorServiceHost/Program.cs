using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService.CalculatorService)))
            {
                host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
                host.AddServiceEndpoint(typeof(CalculatorService.ICalculatorService), new BasicHttpBinding(), "CalculatorService");
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
