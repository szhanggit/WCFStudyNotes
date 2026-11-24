using System.ServiceModel;

namespace MyFirstWcfApp
{
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        string GetData(int value);
    }
}
