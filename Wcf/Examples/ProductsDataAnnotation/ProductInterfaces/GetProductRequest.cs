using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.Serialization;

namespace ProductInterfaces
{
    [DataContract]
    public class GetProductRequest : RequestBase
    {
        [DataMember(IsRequired = true)]
        [Required]
        public string productNumber { get; set; }


        [DataMember]
        [Required]
        [RegularExpression(CommonRegularExpression.VoucherNumber)]
        public string VoucherNumber { get; set; }


        [DataMember]
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        [DataMember]
        public DateTime? TranRealDateTime { get; set; }

        [DataMember]
        public int? SettleDate { get; set; }

        [DataMember]
        [StringLength(50)]
        public string ProductCode { get; set; }
        [DataMember(IsRequired = true)]
        [Required]
        [RegularExpression(@"^\d{15}$")]
        public string MerchantCode { get; set; }
        [DataMember]
        [RegularExpression(@"^[A-Za-z0-9]{1,50}$")]
        public string ShopCode { get; set; }
        [DataMember]
        [DateTime]
        public Nullable<DateTime> ActiveDate { get; set; }

        [DataMember]
        [DateTime]
        public Nullable<DateTime> ExpiryDate { get; set; }
        public override string CheckValid()
        {
            return base.CheckValid();
        }
    }
}
