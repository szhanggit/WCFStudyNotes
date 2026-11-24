using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    public class SimpleService : ISimpleService
    {
        public string GetUserName()
        {
            Console.WriteLine("Is Authenticated: " + ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated);
            Console.WriteLine("Authentication Type: " + ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType);
            Console.WriteLine("Username: " + ServiceSecurityContext.Current.PrimaryIdentity.Name);

            return "Authenticated User Name: " + ServiceSecurityContext.Current.PrimaryIdentity.Name;
        }
    }
}
