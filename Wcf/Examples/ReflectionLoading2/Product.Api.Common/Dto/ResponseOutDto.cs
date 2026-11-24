using System;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class ResponseOutDto
    {
        [DataMember]
        public Guid RequestGuid { get; set; }
        [DataMember]
        public string Response { get; set; }
    }
}
