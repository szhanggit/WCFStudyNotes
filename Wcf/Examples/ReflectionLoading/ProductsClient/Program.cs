using Product.Api.Common;
using Product.Api.Common.Dto;
using ProductInterfaces;
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
            GetListProductsRequest pRequest = new GetListProductsRequest();           
            GetListProductsResponse productListResponse = ProcessResponse<GetListProductsResponse>(ProcessRequest(pRequest, Operation.ListProducts));
            List<string> products = productListResponse.ProductList;

            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Enter a product number to get info about");
            string pNumber = Console.ReadLine();
            //GetProductRequest request = new GetProductRequest();
            //request.productNumber = pNumber;



            //GetProductResponse response = proxy.GetProduct(request);
            //if (response.ResponseCode == ApiResponseCode.Success)
            //{
            //    Console.WriteLine(response.Products.Color);
            //    Console.WriteLine(response.Products.ListPrice);
            //    Console.WriteLine(response.Products.Name);
            //    Console.WriteLine(response.Products.ProductNumber);
            //}
            //else
            //{
            //    Console.WriteLine(response.ResponseCode);
            //}


            Console.ReadKey();
        }

        private static string ProcessRequest(object obj, Operation operation)
        {
            var xmlSerializer = new XmlSerializer();
            RequestDto request = new RequestDto { OperationCode = operation.ToString(), Parameters = xmlSerializer.Serialize(obj), RequestGuid = Guid.NewGuid() };
            string result = null;

            //var requestStr = XmlSerializer<RequestDto>.ObjectToXml(request);
            var requestStr = xmlSerializer.Serialize(request);


            using (ChannelFactory<IWCFProductService> channelFactory = new ChannelFactory<IWCFProductService>("ProductServiceEndpoint"))
            {
                IWCFProductService proxy = channelFactory.CreateChannel();
                result = proxy.Invoke(operation.ToString(), DesHelper.Encrypt(requestStr, ApiConsts.SecurityKey));
            }

            var responseStr = DesHelper.Decrypt(result, ApiConsts.SecurityKey);
            ResponseOutDto r = XmlSerializer<ResponseOutDto>.XmlToObject(responseStr);
            return r.Response;
        }

        private static T ProcessResponse<T>(string response) where T : class
        {
            T result = XmlSerializer<T>.XmlToObject(response);
            return result;
        }
    }
}
