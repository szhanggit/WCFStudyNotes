using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Bursteg.Samples.WCFIntegration.Services;
using System.ServiceModel.Description;
using Bursteg.Samples.WCFIntegration.ServiceContracts;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;

namespace Bursteg.Samples.WCFIntegration.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(OrdersService));
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

            Console.WriteLine("Service is listening. Press any key to close...");
            Console.ReadLine();
            host.Close();
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
