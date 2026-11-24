using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ISimpleService
    {
        [OperationContract]
        int IncrementNumber();
    }
}
