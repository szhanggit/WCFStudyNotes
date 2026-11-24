using ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClient
{
    public class Program
    {
        private static Binding CreateBinding(WCFBinding b)
        {
            Binding result;
            switch (b)
            {
                case WCFBinding.BasicHttpBinding:
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
                    break;
                default:
                    result = new BasicHttpBinding();
                    break;
            }

            return result;
        }

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var binding = CreateBinding(WCFBinding.BasicHttpBinding);
            EndpointAddress endpoint = new EndpointAddress("http://localhost:8082/ProductService");

            //ChannelFactory<IWCFProductService> channelFactory = new ChannelFactory<IWCFProductService>("ProductServiceEndpoint");
            //IWCFProductService proxy = channelFactory.CreateChannel();
            using (ChannelFactory<IWCFProductService> cf = new ChannelFactory<IWCFProductService>(binding, endpoint))
            {
                var client = cf.CreateChannel();
                using (client as IDisposable)
                {
                    try
                    {
                        List<string> products = client.ListProducts();

                        foreach (var p in products)
                        {
                            Console.WriteLine(p);
                        }

                        (client as ICommunicationObject).Close();
                    }
                    catch (Exception ex)
                    {
                        (client as ICommunicationObject).Abort();
                        throw ex;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("ElapsedMilliseconds: " + sw.ElapsedMilliseconds);
        }
    }
}
