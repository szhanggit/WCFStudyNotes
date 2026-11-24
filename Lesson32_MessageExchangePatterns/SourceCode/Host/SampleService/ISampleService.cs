using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleService
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract(IsOneWay = false)]
        string RequestReplyOperation();

        [OperationContract(IsOneWay = false)]
        string RequestReplyOperation_ThrowsException();
    }
}
