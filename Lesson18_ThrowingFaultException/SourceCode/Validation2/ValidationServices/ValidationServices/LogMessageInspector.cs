using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using Message = System.ServiceModel.Channels.Message;

namespace ValidationServices
{
    public class LogMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //logger.InfoFormat("[Incoming]: {0}", request.ToString());
            Console.WriteLine("[Incoming]: {0}", request.ToString());
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //logger.InfoFormat("[Outgoing]: {0}", reply.ToString());
            Console.WriteLine("[Outgoing]: {0}", reply.ToString());
        }
    }
}
