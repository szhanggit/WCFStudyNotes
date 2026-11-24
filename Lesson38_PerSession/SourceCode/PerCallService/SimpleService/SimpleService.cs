using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class SimpleService : ISimpleService
    {
        int _number;
        public int IncrementNumber()
        {
            string SessoinId = OperationContext.Current.SessionId;
            Console.WriteLine("SessionId is: " + SessoinId);
            _number = _number + 1;
            return _number;
        }
    }
}
