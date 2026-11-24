using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloService
{
    public class HelloService : IHelloService
    {
        public string GetMessageWithoutAnyProtection()
        {
            return "Message without signature and encryption";
        }

        public string GetSignedMessage()
        {
            return "Message with signature but without encryption";
        }

        public string GetSignedAndEncryptedMessage()
        {
            return "Message signed and encrypted";
        }
    }
}
