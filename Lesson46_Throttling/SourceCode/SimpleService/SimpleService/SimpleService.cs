using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {
        public void DoWork()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Thread {0} processing request @ {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        }
    }
}
