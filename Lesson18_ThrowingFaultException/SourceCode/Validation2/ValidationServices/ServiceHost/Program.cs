using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using System.ServiceModel.Description;
using OrderServiceContract;

namespace ValidationServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ValidationServices.OrderService)))
            {                
                host.Open();

                // Test the validation
                OperationDescription operation = GetOperationDescription(typeof(IOrdersService), "CreateOrderWithDataContractValidation");
                ValidationParameterInspector validationInspector = new ValidationParameterInspector(operation, "");
                try
                {
                    // Create the data contract parameter to pass to the operation
                    OrderData orderData = new OrderData();
                    orderData.Amount = 3.0;
                    orderData.Currency = "ASD";

                    validationInspector.BeforeCall("CreateOrderWithDataContractValidation", new object[] { orderData });
                }
                catch (FaultException<ValidationFault> e)
                {
                    ValidationFault fault = e.Detail;
                    DisplayFault(fault);
                }

                Console.WriteLine($"Host started at {DateTime.Now.ToString()}");
                Console.ReadKey();
            }
        }

        private static void DisplayFault(ValidationFault faults)
        {
            Console.WriteLine("Fault Occured:");
            foreach (ValidationDetail validationResult in faults.Details)
            {
                Console.WriteLine(string.Format("    Message={0} Key={1} Tag={2}", validationResult.Message, validationResult.Key, validationResult.Tag));
            }
        }

        public static OperationDescription GetOperationDescription(Type contractType, string operationName)
        {
            ContractDescription contract = new ContractDescription(contractType.Name);
            OperationDescription operation = new OperationDescription(operationName, contract);
            operation.SyncMethod = contractType.GetMethod(operationName);
            return operation;
        }
    }
}
