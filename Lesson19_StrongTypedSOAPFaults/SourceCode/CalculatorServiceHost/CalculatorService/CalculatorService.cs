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
            if (Denominator == 0)
                throw new FaultException("Denomintor cannot be ZERO", new FaultCode("DivideByZeroFault"));

            return Numerator / Denominator;
        }
    }
}
