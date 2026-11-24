using Product.Entity;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class GetProductLocationResponse : ResponseDto
    {
        [DataMember]
        public ProductLocation Location { get; set; }
    }
}
