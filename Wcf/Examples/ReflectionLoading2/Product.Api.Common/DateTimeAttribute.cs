using System;
using System.ComponentModel.DataAnnotations;

namespace Product.Api.Common
{
    public class DateTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var dateTime = value as Nullable<DateTime>;

            if (dateTime == null)
            {
                try
                {
                    dateTime = (DateTime)value;

                    return dateTime >= CommonConsts.SqlMinDateTime;
                }
                catch
                {
                }
            }
            else
            {
                return dateTime.HasValue ? dateTime.Value >= CommonConsts.SqlMinDateTime : true;
            }

            return false;
        }
    }
}
