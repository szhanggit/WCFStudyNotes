using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ProductInterfaces
{
    [DataContract]
    public abstract class RequestBase
    {
        public string ConsumerCode { get; set; }
        [DataMember]
        public string RequestId { get; set; }

        public virtual string CheckValid()
        {
            return ApiHelper.Validate(this);
        }
    }
}
