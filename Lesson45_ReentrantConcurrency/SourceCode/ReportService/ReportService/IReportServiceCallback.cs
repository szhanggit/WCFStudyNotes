using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ReportService
{
    public interface IReportServiceCallback
    {
        // Since we have not set IsOnway=true, the operation is Request/Reply operation
        [OperationContract]
        void Progress(int percentageComplete);
    }
}
