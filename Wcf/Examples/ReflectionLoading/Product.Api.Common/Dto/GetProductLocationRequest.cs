using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class GetProductLocationRequest : RequestBase
    {
        [DataMember(IsRequired = true)]
        [Required]
        public int productLocationId { get; set; }

        public override string CheckValid()
        {
            return base.CheckValid();
        }
    }
}
