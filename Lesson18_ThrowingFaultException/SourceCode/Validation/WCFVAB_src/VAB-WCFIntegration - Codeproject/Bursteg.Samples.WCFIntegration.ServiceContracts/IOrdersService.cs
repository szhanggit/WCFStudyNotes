using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;

namespace Bursteg.Samples.WCFIntegration.ServiceContracts
{
[ServiceContract(Name="IOrdersService", Namespace="http://bursteg.net/Samples/WCFIntegration/07/04")]
[ValidationBehavior]
public interface IOrdersService
{
    [OperationContract(Name="CreateOrder")]
    int CreateOrder(string currency, double amount);

    [OperationContract(Name = "CreateOrderWithParametersValidation")]
    [FaultContract(typeof(ValidationFault))]
    int CreateOrderWithParametersValidation(
        [NotNullValidator] string currency, 
        [RangeValidator(1.0, RangeBoundaryType.Inclusive, 2.0, RangeBoundaryType.Inclusive)] double amount);

    [FaultContract(typeof(ValidationFault))]
    [OperationContract(Name = "CreateOrderWithDataContractValidation")]
    OrderInfo CreateOrderWithDataContractValidation(OrderData orderData);
}
}
