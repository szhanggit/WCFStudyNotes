using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace OrderServiceContract
{
    [ServiceContract(Name = "IOrdersService", Namespace = "http://bursteg.net/Samples/WCFIntegration/07/04")]
    [ValidationBehavior]
    public interface IOrdersService
    {
        [OperationContract(Name = "CreateOrder")]
        int CreateOrder(string currency, double amount);

        [FaultContract(typeof(ValidationFault))]
        [OperationContract(Name = "CreateOrderWithParametersValidation")]
        int CreateOrderWithParametersValidation(
            [NotNullValidator]
            string currency,
            [RangeValidator(1.0, RangeBoundaryType.Inclusive, 2.0, RangeBoundaryType.Inclusive)]
            double amount);

        [FaultContract(typeof(ValidationFault))]
        [OperationContract(Name = "CreateOrderWithDataContractValidation")]
        OrderInfo CreateOrderWithDataContractValidation(OrderData orderData);
    }
}
