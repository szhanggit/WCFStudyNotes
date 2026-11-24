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
        public string RequestReplyOperation()
        {
            DateTime dtStart = DateTime.Now;
            Thread.Sleep(2000);
            DateTime dtEnd = DateTime.Now;

            return dtEnd.Subtract(dtStart).Seconds.ToString() + " seconds processing time";
        }

        // This method throws an NotImplementedException exception
        public string RequestReplyOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }
    }
}
