using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    [LogEndpointBehavior]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int Numerator, int Denominator)
        {
            //if (Denominator == 0)
            //    throw new FaultException("Denomintor cannot be ZERO", new FaultCode("DivideByZeroFault"));

            //return Numerator / Denominator;
            try
            {
                return Numerator / Denominator;
            }
            catch (Exception e)
            {
                throw GetEvSysException(e);
            }
        }

        private FaultException<EvSystemException> GetEvSysException(Exception e)
        {
            while (e.InnerException != null)
                e = e.InnerException;

            EvSystemException fault = new EvSystemException() { Message = e.Message, Source = e.Source, StackTrace = e.StackTrace };
            //return new FaultException<EvSystemException>(fault, new FaultReason(e.Message));
            return new FaultException<EvSystemException>(fault);
        }
    }
}
