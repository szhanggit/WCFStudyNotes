using ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IWCFProductService> channelFactory = new ChannelFactory<IWCFProductService>("ProductServiceEndpoint");
            IWCFProductService proxy = channelFactory.CreateChannel();

            List<string> products = proxy.ListProducts();

            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Enter a product number to get info about");
            string pNumber = Console.ReadLine();

            ProductData data = proxy.GetProduct(pNumber);
            Console.WriteLine(data.Color);
            Console.WriteLine(data.ListPrice);
            Console.WriteLine(data.Name);
            Console.WriteLine(data.ProductNumber);

            Console.ReadKey();
        }
    }
}
