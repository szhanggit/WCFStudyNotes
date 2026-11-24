using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ValidationClient.OrdersService;

namespace ValidationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Press any key when the service is listening...");
                Console.ReadLine();

                // Call a service operation without any parameters validation
                NoValidation();

                // Call a service operation that validates parameters
                ParametersValidation();

                // Call a service operation that validates data contract parameters
                DataContractValidation();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Press any key to close...");
                Console.ReadLine();
            }
        }

        private static void NoValidation()
        {
            Console.WriteLine("\nNo Validation:");
            Console.WriteLine("This test calls a service operation that has " +
                "no validation checks." +
                "This service call should not fail.");

            // Create an instance of the service proxy
            OrdersServiceClient proxy = new OrdersServiceClient();

            // This method has no validations in it. It should be OK
            int orderID = proxy.CreateOrder("USD", 3.0);
            Console.WriteLine("Order with ID " + orderID.ToString() + " was created.");
        }

        private static void DisplayFault(ValidationFault faults)
        {
            Console.WriteLine("Fault Occured:");
            foreach (ValidationDetail validationResult in faults.Details)
            {
                Console.WriteLine(string.Format("    Message={0} Key={1} Tag={2}", validationResult.Message, validationResult.Key, validationResult.Tag));
            }
        }

        private static void ParametersValidation()
        {
            try
            {
                Console.WriteLine("\nParameters Validation:");
                Console.WriteLine("This test calls a service operation that receives" +
                    "parameters that has some validations defined on in the service contract." +
                    "This service call should fail.");

                // Validate parameters. This operation has validation on the parameters
                // defined in the service contract definition
                // Create an instance of the service proxy
                OrdersServiceClient proxy = new OrdersServiceClient();

                // This method has no validations in it. It should be OK
                int orderID = proxy.CreateOrderWithParametersValidation("USD", 3.0);

                // The code should never reach here if the validation is enabled
                Console.WriteLine("Order with ID " + orderID.ToString() + " was created.");
            }
            catch (FaultException<ValidationFault> ex)
            {
                DisplayFault(ex.Detail);
            }
        }

        private static void DataContractValidation()
        {
            try
            {
                // Validate parameters. This operation has validation on the parameters
                // defined in the service contract definition
                Console.WriteLine("\nData Contract Validation:");
                Console.WriteLine("This test calls a service operation that receives a" +
                    "parameter of type OrderData that has some validations defined on it." +
                    "This service call should fail.");

                // Create an instance of the service proxy
                OrdersServiceClient proxy = new OrdersServiceClient();

                // This method has no validations in it. It should be OK
                OrderData orderData = new OrderData();
                orderData.Amount = 3.0;
                orderData.Currency = "ASD";
                OrderInfo info = proxy.CreateOrderWithDataContractValidation(orderData);

                // The code should never reach here if the validation is enabled
                Console.WriteLine("Order with ID " + info.OrderID.ToString() + " was created.");
            }
            catch (FaultException<ValidationFault> ex)
            {
                DisplayFault(ex.Detail);
            }
        }
    }
}
