using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Runtime.Serialization;

namespace OrderServiceContract
{
    [HasSelfValidation]
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


        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            string msg = string.Empty;
            if (Amount < 100)
            {
                msg = "The amount cannot be less than 100.";
                results.AddResult(new ValidationResult(msg, this, "Amount", "", null));
            }
        }
    }
}
