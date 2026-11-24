using System.Runtime.Serialization;

namespace ProductInterfaces
{
    [DataContract]
    public class GetProductResponse : ResponseDto
    {
        [DataMember]
        public ProductData Products { get; set; }
    }
}
