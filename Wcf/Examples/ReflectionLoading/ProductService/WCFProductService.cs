using Product.Api.Common;
using Product.Api.Common.Dto;
using Product.Entity;
using ProductInterfaces;
using ProductUtilities;
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
        private XmlSerializer xmlSerializer = null;
        public WCFProductService() {
            xmlSerializer = new XmlSerializer();
        }

        public string Invoke(string operationcode, string parameters)
        {
            string result = null;
            var parsedOperation = Operation.Unknown;
            if (Enum.TryParse<Operation>(operationcode, out parsedOperation))
            {
                switch (parsedOperation)
                {
                    case Operation.ListProducts:
                        ProcessRequestToService<GetListProductsRequest, GetListProductsResponse>(operationcode, parameters, (getListProductsRequest) => ListProducts(getListProductsRequest), ref result);
                        break;
                    case Operation.GetProduct:

                    break;
                    case Operation.GetProductLocation:

                    break;
                    case Operation.GetProductDocument:

                    break;
                    default: break;                    
                }
            }

            return result;
        }

        private void ProcessRequestToService<T, TResult>(string operationCode, string parameters, Func<T, ResponseDto> invokeMethod, ref string result)
        where T : RequestBase
        where TResult : class
        {
            result = ProcessRequest<T>(operationCode, parameters, invokeMethod, result);
        }

        private string ProcessRequest<T>(string operationCode, string parameters, Func<T, ResponseDto> invokeMethod, string result, SecurityAlgorithm securityAlgorithm = SecurityAlgorithm.DES) where T : RequestBase
        {
            string decryptParameters;
            RequestDto request;

            try
            {
                decryptParameters = DesHelper.Decrypt(parameters, ApiConsts.SecurityKey);
                request = XmlSerializer<RequestDto>.XmlToObject(decryptParameters);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto() { ResponseCode = ApiResponseCode.InvalidRequest, Message = ex.Message };
                var responseDto = XmlSerializer<ResponseOutDto>.ObjectToXml(new ResponseOutDto
                {
                    Response = xmlSerializer.Serialize(response)
                });
                result = DesHelper.Encrypt(responseDto, ApiConsts.SecurityKey);
                return result;
            }

            if (request != null && request.OperationCode == operationCode)
            {
                var t = XmlSerializer<T>.XmlToObject(request.Parameters);

                if (t != null)
                {
                    t.RequestId = request.RequestGuid.ToString();
                    var response = invokeMethod(t);
                    var responseDto = XmlSerializer<ResponseOutDto>.ObjectToXml(new ResponseOutDto
                    {
                        Response = xmlSerializer.Serialize(response),
                        RequestGuid = request.RequestGuid
                    });

                    result = DesHelper.Encrypt(responseDto, ApiConsts.SecurityKey);
                }
            }
            return result;
        }

        public GetListProductsResponse ListProducts(GetListProductsRequest request)
        {
            Console.WriteLine("ListProducts() has been called by a client.");
            List<string> productsList = new List<string>();
            GetListProductsResponse response = null;
            response = new GetListProductsResponse { ResponseCode = request.CheckValid() };

            if (string.IsNullOrEmpty(response.ResponseCode))
            {
                using (AdventureWorksEntities database = new AdventureWorksEntities())
                {
                    var products = from p in database.Product select p.ProductNumber;
                    productsList = products.ToList();
                    response.ProductList = productsList;
                    response.ResponseCode = ApiResponseCode.Success;
                }
            }

            return response;
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

        public GetProductLocationResponse GetProductLocation(GetProductLocationRequest request)
        {
            ProductLocation productLocation = null;
            GetProductLocationResponse response = null;

            try
            {
                if (request != null)
                {
                    response = new GetProductLocationResponse { ResponseCode = request.CheckValid() };

                    if (string.IsNullOrEmpty(response.ResponseCode))
                    {
                        using (AdventureWorksEntities database = new AdventureWorksEntities())
                        {
                            Location matchingProductLocation = database.Location.First((p) => p.LocationID == request.productLocationId);

                            productLocation = new ProductLocation();
                            productLocation.Name = matchingProductLocation.Name;
                            productLocation.Availability = matchingProductLocation.Availability;
                            productLocation.CostRate = matchingProductLocation.CostRate;
                            productLocation.LocationId = matchingProductLocation.LocationID;
                            productLocation.ModifiedDate = matchingProductLocation.ModifiedDate;

                            response.Location = productLocation;
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

        public GetProductDocumentResponse GetProductDocument(GetProductDocumentRequest request)
        {
            ProductDocument productDocument = null;
            GetProductDocumentResponse response = null;

            try
            {
                if (request != null)
                {
                    response = new GetProductDocumentResponse { ResponseCode = request.CheckValid() };

                    if (string.IsNullOrEmpty(response.ResponseCode))
                    {
                        using (AdventureWorksEntities database = new AdventureWorksEntities())
                        {
                            Document matchingProductDocument = database.Document.First((p) => p.DocumentID == request.productDocumentId);

                            productDocument = new ProductDocument();
                            productDocument.DocumentId = matchingProductDocument.DocumentID;
                            productDocument.FileExtension = matchingProductDocument.FileExtension;
                            productDocument.FileName = matchingProductDocument.FileName;
                            productDocument.Title = matchingProductDocument.Title;

                            response.Documents = productDocument;
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
