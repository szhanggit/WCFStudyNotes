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
            GetProductRequest request = new GetProductRequest();
            request.productNumber = pNumber;

            GetProductResponse response = proxy.GetProduct(request);
            if (response.ResponseCode == ApiResponseCode.Success)
            {
                Console.WriteLine(response.Products.Color);
                Console.WriteLine(response.Products.ListPrice);
                Console.WriteLine(response.Products.Name);
                Console.WriteLine(response.Products.ProductNumber);
            }
            else
            {
                Console.WriteLine(response.ResponseCode);
            }


            Console.ReadKey();
        }
    }
}
