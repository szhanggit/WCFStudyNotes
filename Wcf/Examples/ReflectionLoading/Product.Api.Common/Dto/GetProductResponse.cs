using Product.Entity;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class GetProductResponse : ResponseDto
    {
        [DataMember]
        public ProductData Products { get; set; }
    }
}
