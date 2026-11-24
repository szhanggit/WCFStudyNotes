using Product.Api.Common;
using System;
using System.Runtime.Serialization;

namespace Product.Api.Common
{
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// API Exception ResponseCode
        /// </summary>
        public string ResponseCode { get; set; }

        public ApiException()
            : this(ApiResponseCode.Fail)
        {
        }

        public ApiException(string responseCode)
            : base(responseCode)
        {
            ResponseCode = responseCode;
        }

        public ApiException(string responseCode, Exception innerException)
            : base(responseCode, innerException)
        {
            ResponseCode = responseCode;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
