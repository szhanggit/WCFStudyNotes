using Product.Entity;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class GetProductDocumentResponse : ResponseDto
    {
        [DataMember]
        public ProductDocument Documents { get; set; }
    }
}
