using Product.Api.Common;
using Product.Api.Common.Dto;
using ProductInterfaces;
using ProductsClient.ClientLib;
using ProductUtilities;
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
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            ProductManager product = new ProductManager();

            var result = product.GetListProducts(new GetListProductsRequest() {
                RequestId = Guid.NewGuid().ToString()
            });

            sw.Stop();

            List<string> products = result.ProductList;

            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }
}
