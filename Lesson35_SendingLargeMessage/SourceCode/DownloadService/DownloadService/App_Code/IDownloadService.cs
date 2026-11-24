using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DownloadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IDownloadService
    {
        [OperationContract]
        File DownloadDocument();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class File
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public byte[] Content { get; set; }
    }
}

