using ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“WCFProductService”。
    public class WCFProductService : IWCFProductService
    {
        public List<string> ListProducts()
        {
            Console.WriteLine("ListProducts() has been called by a client.");
            List<string> productsList = new List<string>();
            try
            {
                using (AdventureWorksEntities database = new AdventureWorksEntities())
                {
                    var products = from p in database.Product
                                   select p.ProductNumber;

                    productsList = products.ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return productsList;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            ProductData productData = null;
            GetProductResponse response = null;

            try
            {
                if (request != null)
                {
                    response = new GetProductResponse { ResponseCode = request.CheckValid() };

                    if (string.IsNullOrEmpty(response.ResponseCode))
                    {
                        using (AdventureWorksEntities database = new AdventureWorksEntities())
                        {
                            Product matchingProduct = database.Product.First((p) => p.ProductNumber == request.productNumber);

                            productData = new ProductData();
                            productData.Name = matchingProduct.Name;
                            productData.ProductNumber = matchingProduct.ProductNumber;
                            productData.ListPrice = (double)matchingProduct.ListPrice;
                            productData.Color = matchingProduct.Color;
                            response.Products = productData;
                            response.ResponseCode = ApiResponseCode.Success;
                        }
                    }
                }
            }
            catch
            {
                
            }

            return response;
        }
    }
}
