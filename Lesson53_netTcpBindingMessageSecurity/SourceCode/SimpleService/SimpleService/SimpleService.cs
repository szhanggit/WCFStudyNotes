using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    public class SimpleService : ISimpleService
    {
        public string GetMessage(string name)
        {
            return "Hello " + name;
        }
    }
}
