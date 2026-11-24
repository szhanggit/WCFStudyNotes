using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Bursteg.Samples.WCFIntegration.ServiceContracts
{
    [DataContract(Name = "OrderData", Namespace = "http://bursteg.net/Samples/WCFIntegration/07/04")]
    public class OrderData
    {
        private double amount;
        private string currency;

        [DataMember(Name = "Amount", Order = 1)]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        [DataMember(Name = "Currency", Order = 2)]
        [DomainValidator("USD", "EUR", "JPY")]
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
    }
}
