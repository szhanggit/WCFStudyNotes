using Product.Api.Common;
using Product.Api.Common.Dto;
using Product.Entity;
using ProductInterfaces;
using ProductUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Runtime.Caching;
using System.IO;

namespace ProductService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“WCFProductService”。
    public class WCFProductService : IWCFProductService
    {
        private XmlSerializer xmlSerializer = null;
        private static Lazy<Dictionary<string, Dictionary<string, string>>> remoteServiceConfig = new Lazy<Dictionary<string, Dictionary<string, string>>>(InitRemoteServiceConfig, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        private static object objLock = new object();

        public WCFProductService() {
            xmlSerializer = new XmlSerializer();
        }

        private object InvokeMethod(string typeFullName, string methodName, object request)
        {
            Type type = Type.GetType(typeFullName);
            MethodInfo methodInfo = type.GetMethod(methodName);
            object MeObj = Activator.CreateInstance(type);
            return methodInfo.Invoke(MeObj, new object[] { request });
        }

        public string Invoke(string messageId, string operationName, string requestMessage)
        {
            if (string.IsNullOrEmpty(messageId) || string.IsNullOrEmpty(operationName) || string.IsNullOrEmpty(requestMessage))
            {
                throw new ApiException(ApiResponseCode.InvalidRequest);
            }
            if (!Throttle(messageId))
            {
                throw new ApiException(ApiResponseCode.Fail);
            }

            string result = string.Empty;
            try
            {
                if (!CheckCallPermission(operationName))
                {
                    throw new NotImplementedException();
                }
                requestMessage = DecryptRequestMessage(operationName, requestMessage);
                XmlSerializer XmlSerializer = new XmlSerializer();
                var request = XmlSerializer.XmlToObject(RemoteServiceRequestTypeConfig.GetOperationRequestType(operationName), requestMessage);
                if (request != null)
                {
                    string requestId = request.GetKey("RequestId").ToString();
                    var messageLogEnabled = remoteServiceConfig.Value.ContainsKey(operationName) ? bool.Parse(remoteServiceConfig.Value[operationName]["MessageLogEnabled"]) : false;
                    var response = this.InvokeMethod(remoteServiceConfig.Value[operationName]["TypeFullName"], remoteServiceConfig.Value[operationName]["MethodName"], request);
                    response.SetKey("RequestId", requestId);
                    var responseMessage = Serialize(response);
                    result = EncryptResponseMessage(operationName, responseMessage);
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(ApiResponseCode.Fail);
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

        public GetListProductsResponse GetListProducts(GetListProductsRequest request)
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

        private static Dictionary<string, Dictionary<string, string>> InitRemoteServiceConfig()
        {
            var remoteServiceConfig = new Dictionary<string, Dictionary<string, string>>();
            var xmldoc = new XmlDocument();
            string path = string.Format("{0}\\{1}", (Directory.GetCurrentDirectory()+ "\\..\\.."), "RemoteService.config");
            xmldoc.Load(path);
            var nodes = xmldoc.SelectNodes("RemoteService/Operation");
            foreach (XmlElement node in nodes)
            {
                var dic = new Dictionary<string, string>();
                dic.Add("AuthorizeEnabled", node.GetAttribute("AuthorizeEnabled"));
                dic.Add("EncryptEnabled", node.GetAttribute("EncryptEnabled"));
                dic.Add("MessageLogEnabled", node.GetAttribute("MessageLogEnabled"));
                dic.Add("TypeFullName", node.GetAttribute("TypeFullName"));
                dic.Add("MethodName", node.GetAttribute("MethodName"));
                remoteServiceConfig.Add(node.GetAttribute("Name"), dic);
            }

            return remoteServiceConfig;
        }

        private bool Throttle(string messageId)
        {
            var limit = 500;
            var expireSeconds = 1;
            string throttleCacheValue = "$Throttle$Cache$";
            bool result = true;
            var throttleCache = MemoryCache.Default;
            lock (objLock)
            {
                //logger.InfoFormat("requst cache size: {0}", throttleCache.Count(k => throttleCacheValue.Equals(k.Value)));
                if (throttleCache.Count(k => throttleCacheValue.Equals(k.Value)) >= limit)
                {
                    result = false;
                }
                else
                {
                    result = throttleCache.Add(messageId, throttleCacheValue, DateTimeOffset.Now.AddSeconds(expireSeconds));
                }
            }

            return result;
        }

        private bool CheckCallPermission(string operationName)
        {
            var authorizeEnabled = remoteServiceConfig.Value.ContainsKey(operationName) ? bool.Parse(remoteServiceConfig.Value[operationName]["AuthorizeEnabled"]) : false;
            if (authorizeEnabled)
            {
                throw new NotImplementedException();
            }
            else
            {
                return true;
            }
        }

        private string DecryptRequestMessage(string operationName, string requestMessage)
        {
            string ret = requestMessage;
            var encryptEnabled = remoteServiceConfig.Value.ContainsKey(operationName) ? bool.Parse(remoteServiceConfig.Value[operationName]["EncryptEnabled"]) : false;
            if (encryptEnabled)
            {
                ret = DesHelper.Decrypt(requestMessage, ApiConsts.SecurityKey);
            }

            return ret;
        }

        private string EncryptResponseMessage(string operationName, string responseMessage)
        {
            string ret = responseMessage;
            var encryptEnabled = remoteServiceConfig.Value.ContainsKey(operationName) ? bool.Parse(remoteServiceConfig.Value[operationName]["EncryptEnabled"]) : false;
            if (encryptEnabled)
            {
                ret = DesHelper.Encrypt(responseMessage, ApiConsts.SecurityKey);
            }

            return ret;
        }

        private RequestBase Deserialize(Type type, string message)
        {
            //TODO: Serializer config
            XmlSerializer XmlSerializer = new XmlSerializer();
            return XmlSerializer.XmlToObject(type, message) as RequestBase;
        }

        private string Serialize(object obj)
        {
            //TODO: Serializer config
            XmlSerializer XmlSerializer = new XmlSerializer();
            return XmlSerializer.Serialize(obj);
        }
    }
}
