using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleService.SimpleServiceClient client = new SimpleService.SimpleServiceClient();
            int number = client.IncrementNumber();
            Console.WriteLine("Number after first call = " + number);
            Console.WriteLine("SessionId is: " + client.InnerChannel.SessionId);
            number = client.IncrementNumber();
            Console.WriteLine("Number after second call = " + number);
            Console.WriteLine("SessionId is: " + client.InnerChannel.SessionId);
            number = client.IncrementNumber();
            Console.WriteLine("Number after third call = " + number);
            Console.WriteLine("SessionId is: " + client.InnerChannel.SessionId);
            Console.ReadKey();
        }
    }
}
