using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
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
