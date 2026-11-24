using System.ServiceModel;

namespace Consumer.Service
{
    [ServiceContract]
    public interface IConsumerCacheManagement
    {
        [OperationContract]
        void RefreshAll();
    }
}
