using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int Numerator, int Denominator)
        {
            try
            {
                return Numerator / Denominator;
            }
            catch (DivideByZeroException ex)
            {
                DivideByZeroFault divideByZeroFault = new DivideByZeroFault();
                divideByZeroFault.Error = ex.Message;
                divideByZeroFault.Details = "Denominator cannot be ZERO";

                throw new FaultException<DivideByZeroFault>(divideByZeroFault);
            }
        }
    }
}
