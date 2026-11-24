using System.ServiceModel;

namespace ProductsClient
{
    [ServiceContract]
    public interface IRemoteService
    {
        [OperationContract]
        [FaultContract(typeof(ApiException))]
        string Invoke(string messageId, string consumerCode, string operationName, string requestMessage, string checkSum = null, string token = null);
    }
}
