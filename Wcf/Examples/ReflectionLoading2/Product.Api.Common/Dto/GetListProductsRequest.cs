using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    public class GetListProductsRequest : RequestBase
    {
        public override string CheckValid()
        {
            return base.CheckValid();
        }
    }
}
