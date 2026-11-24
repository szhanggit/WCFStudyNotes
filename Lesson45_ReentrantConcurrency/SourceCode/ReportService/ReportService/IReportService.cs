using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ReportService
{
    // Associate callback contract with service contract using CallbackContract attribute
    [ServiceContract(CallbackContract = typeof(IReportServiceCallback))]
    public interface IReportService
    {
        [OperationContract]
        void ProcessReport();
    }
}
