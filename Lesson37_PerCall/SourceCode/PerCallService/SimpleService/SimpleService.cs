using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {
        int _number;
        public int IncrementNumber()
        {
            _number = _number + 1;
            return _number;
        }
    }
}
