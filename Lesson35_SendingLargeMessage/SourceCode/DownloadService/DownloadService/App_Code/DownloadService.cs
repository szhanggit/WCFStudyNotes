using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DownloadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class DownloadService : IDownloadService
    {
        public File DownloadDocument()
        {
            File file = new File();
            file.Content = System.IO.File.
                ReadAllBytes(@"D:\download\billingbox\20200626.reimbursement.dat");
            file.Name = "20200626.reimbursement.dat";

            return file;
        }
    }
}
