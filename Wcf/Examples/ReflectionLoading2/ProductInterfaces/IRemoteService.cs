using Product.Api.Common;
using System;
using System.ServiceModel;

namespace ProductsClient.ClientLib
{
    [ServiceContract]
    public interface IRemoteService
    {
        [OperationContract]
        [FaultContract(typeof(ApiException))]
        string Invoke(string messageId, string operationName, string requestMessage);
    }
}
