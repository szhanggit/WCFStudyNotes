using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Product.Api.Common;

namespace Product.Api.Common.Dto
{
    [Serializable]
    public abstract class RequestBase
    {
        public string ConsumerCode { get; set; }

        /// <summary>
        /// Every request should have a uniqueue Id
        /// </summary>
        [Required]
        public string RequestId { get; set; }

        public virtual string CheckValid()
        {
            return Validate(this) ? null : ApiResponseCode.InvalidRequest;
        }

        private bool Validate(object obj)
        {
            List<ValidationResult> list = new List<ValidationResult>();
            bool flag = Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), list, true);
            return flag;
        }
    }
}
