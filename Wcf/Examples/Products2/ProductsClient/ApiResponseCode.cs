using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClient
{
    public static class ApiResponseCode
    {
        public const string Success = "0000";
        public const string Fail = "9999";
        public const string InvalidRequest = "MA0001";
        public const string RequestItemNotExist = "MA0002";
        public const string DateNotProvide = "MA0003";
        public const string SendEmailFail = "MA0004";
        public const string SendSmsFail = "MA0005";
        public const string SendEmailAndSmsFail = "MA0006";
        public const string EmailAddressNotExist = "MA0007";
        public const string MobileNotExist = "MA0008";
        public const string ServerDataError = "MA0009";
        public const string VoucherInsuffient = "MA0010";
        public const string IssueVoucherFail = "MA0011";
        public const string MissingTempalte = "MA0012";
        public const string OutOfDateRange = "MA0013";
        public const string ResponseItemIsEmpty = "MA0014";
        public const string ExceedMaxQuantity = "MA0020";
        public const string ConsumerCodeNotExist = "MA0021";
        public const string VoucherNumberNotExist = "MA0022";
        public const string ShopNotExist = "MA0023";
        public const string RedemptVoucherFail = "MA0024";
        public const string VoucherCannotResend = "MA0025";
        public const string NoActiveAcceptanceLoop = "MA0026";
        public const string PartSuccess = "MA0027";
        public const string AccountNotActive = "MA0028";
        public const string InvalidSoldPrice = "MA0029";
        public const string InvalidRequestQuantity = "MA0030";
        public const string CTBCOrderExist = "MA0031";
        public const string ProductNotExist = "MA0032";
        public const string ActivePreIssueVoucherFailed = "MA0033";
        public const string OrderIsPublished = "MA0034";
        public const string InvalidAvailableQuantity = "MA0036";
        public const string InvalidOrderStatus = "MA0037";
        public const string OrderNumberNotExist = "MA0038";

        public const string ProgramNotExist = "M0064";
        public const string InvalidMerchantID = "M0074";
        public const string InvalidAmount = "M0075";
        public const string InvalidShopCode = "M0076";
        public const string InvalidTerminalCode = "M0077";
        public const string InvalidSettleDate = "M0078";
        public const string InvalidVoucherNumber = "M0079";
        public const string InvalidTranType = "M0085";
        public const string InvalidTranRealDateTime = "M0086";
    }
}
