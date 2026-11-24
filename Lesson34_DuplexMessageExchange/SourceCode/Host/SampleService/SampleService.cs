using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleService
{
    public class SampleService : ISampleService
    {
        // This method simply introduces 2 seconds of artifical processing
        // time using Thread.Sleep(2000) and returns a string
        public void OneWayOperation()
        {
            Thread.Sleep(2000);
            return;
        }

        // This method throws an NotImplementedException exception
        public void OneWayOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }
    }
}
