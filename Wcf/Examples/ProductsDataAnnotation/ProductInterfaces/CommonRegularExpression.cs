using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInterfaces
{
    public static class CommonRegularExpression
    {
        public const string VoucherNumber = "[0-9a-zA-Z]{5,27}";
        public const string ProgramCode = @"^\d{1,50}$";
        public const string OrderNumber = @"^\d{12}$";
        public const string ValidEmail = @"^([0-9a-zA-Z_]+[-._+&amp;])*[0-9a-zA-Z_.-]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
    }
}
