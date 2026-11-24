using Product.Api.Common;
using Product.Api.Common.Dto;
using ProductInterfaces;
using ProductUtilities;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Serialization;

namespace ProductsClient.ClientLib
{
    public class ClientBase
    {
        private ProductUtilities.XmlSerializer xmlSerializer;

        public ClientBase()
        {
            xmlSerializer = new ProductUtilities.XmlSerializer();
        }

        public virtual string Invoke(string operationName, RequestBase request)
        {
            if (string.IsNullOrEmpty(operationName) || request == null)
            {
                throw new ApiException(ApiResponseCode.InvalidRequest);
            }

            string result = null;
            string requestMessage = xmlSerializer.Serialize(request);
            requestMessage = DesHelper.Encrypt(requestMessage, ApiConsts.SecurityKey);
            var binding = this.CreateBinding();
            EndpointAddress endpoint = new EndpointAddress("http://localhost:8084/ProductService");
            using (ChannelFactory<IWCFProductService> cf = new ChannelFactory<IWCFProductService>(binding, endpoint))
            {
                var client = cf.CreateChannel();
                using (client as IDisposable)
                {
                    try
                    {
                        result = client.Invoke(request.RequestId, operationName, requestMessage);
                        (client as ICommunicationObject).Close();
                    }
                    catch
                    {
                        (client as ICommunicationObject).Abort();
                        throw;
                    }
                }
            }

            return result;
        }

        private Binding CreateBinding()
        {
            Binding result = null;
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            basicHttpBinding.MaxBufferSize = int.MaxValue;
            basicHttpBinding.MaxBufferPoolSize = int.MaxValue;
            basicHttpBinding.MaxReceivedMessageSize = int.MaxValue;
            basicHttpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            basicHttpBinding.CloseTimeout = new TimeSpan(0, 10, 0);
            basicHttpBinding.OpenTimeout = new TimeSpan(0, 10, 0);
            basicHttpBinding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            basicHttpBinding.SendTimeout = new TimeSpan(0, 10, 0);
            result = basicHttpBinding;


            return result;
        }

        protected ResponseBase DeserializeResponse(Type type, string message)
        {
            ProductUtilities.XmlSerializer XmlSerializer = new ProductUtilities.XmlSerializer();
            return XmlSerializer.XmlToObject(type, message) as ResponseBase;
        }
    }
}
