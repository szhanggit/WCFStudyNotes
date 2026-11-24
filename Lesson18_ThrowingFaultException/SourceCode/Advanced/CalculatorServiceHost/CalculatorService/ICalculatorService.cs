using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    [ServiceContract]
    [ValidationBehavior]
    public interface ICalculatorService
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(EvSystemException))]
        int Divide(int Numerator, int Denominator);
    }
}
