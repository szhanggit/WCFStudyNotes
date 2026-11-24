using System;
using System.Runtime.Serialization;

namespace Product.Api.Common.Dto
{
    [Serializable]
    public class ResponseBase
    {
        /// <summary>
        /// "0000": Success, others mean fail
        /// </summary>
        public string ResponseCode { get; set; }

        /// <summary>
        /// Message to explain the result
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Raw request Id
        /// </summary>
        public string RequestId { get; set; }
    }
}
