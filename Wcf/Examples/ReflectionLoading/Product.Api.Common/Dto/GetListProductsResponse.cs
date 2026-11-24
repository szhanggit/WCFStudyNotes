using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class GetListProductsResponse : ResponseDto
    {
        [DataMember]
        public List<string> ProductList { get; set; }
    }
}
