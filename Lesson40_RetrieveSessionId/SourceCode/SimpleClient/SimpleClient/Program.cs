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

            try
            {
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
            catch (System.ServiceModel.CommunicationException)
            {
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    string strMessage = "Session timed out. Your existing session will be lost.";
                    strMessage += "A new session will now be created";
                    Console.WriteLine(strMessage);
                    client = new SimpleService.SimpleServiceClient();
                }
            }
        }
    }
}
