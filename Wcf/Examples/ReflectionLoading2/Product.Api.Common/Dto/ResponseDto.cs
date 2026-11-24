using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [DataContract]
    public class ResponseDto
    {
        private string responseCode;

        [DataMember]
        public string ResponseCode
        {
            get
            {
                return responseCode;
            }
            set
            {
                responseCode = value;
                //Message = ApiHelper.GetMessage(ResponseCode);
            }
        }

        [DataMember]
        public string Message { get; set; }
    }
}
