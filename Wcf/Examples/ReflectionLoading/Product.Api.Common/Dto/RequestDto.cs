using System;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class RequestDto
    {
        [DataMember]
        public string OperationCode { get; set; }
        [DataMember]
        public string Parameters { get; set; }
        [DataMember]
        public Guid RequestGuid { get; set; }
    }
}
