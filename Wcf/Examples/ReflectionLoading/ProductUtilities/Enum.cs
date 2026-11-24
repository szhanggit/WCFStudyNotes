using System;
using System.Text.RegularExpressions;

namespace ProductUtilities
{
    public enum SecurityAlgorithm
    {
        DES = 1,
        AES = 2
    }

    public enum Operation
    {
        TestCheckVoucherQuantity,
        CheckVoucherQuantity,
        SendVoucher,
        GetVoucher,
        ResendVoucher,
        QueryTransactionByShop,
        QueryVoucherStatus,
        TrashVoucher,
        QueryVoucherDeliveryStatus,
        QueryTransactionHistoryByShop,
        QueryLastRedemptionByShop,
        DoBatchTransaction,
        ConfirmConsume,
        Unknown,
        QueryExecutionResult,
        CheckOrderStatus,
        GetMultiVouchers,
        BlockVouchers,
        UnBlockVouchers,
        TrashVouchers,
        GetMerchantReport,
        GetMerchantReportDetail,
        UpdateClientOrderNumber,
        GetMultiVouchersV2,
        GetMultiVouchersV3,
        GetVoucherV2,
        SendVoucherV3,
        GetVoucherV3,
        CheckOrderStatusForMultiVouchers,
        GetProdInfoByOrder,
        GetMerchantReportDetailV2,
        TrashVoucherV2,
        SendMultiVouchers,
        GetVoucherSSN,
        GetInventoryInfo,
        GetInventoryInfoList,
        GetVoucherV4,
        GetMultiVouchersV4,
        SendVoucherV4,
        SendMultiVouchersV4,
        GetVoucherV5,
        GetMultiVouchersV5,
        GetMultiVouchersV6,
        ListProducts,
        GetProduct,
        GetProductLocation,
        GetProductDocument
    }


    public static class Code
    {
        public const string GetVoucher = "GetVoucher";
        public const string GetInventoryInfo = "GetInventoryInfo";
        public const string GetInventoryInfoList = "GetInventoryInfoList";
        public const string CheckVoucherQuantity = "CheckVoucherQuantity";
        public const string SendVoucher = "SendVoucher";
        public const string ResendVoucher = "ResendVoucher";
        public const string SendMultiVouchers = "SendMultiVouchers";
        public const string TrashVoucher = "TrashVoucher";
        public const string QueryVoucherStatus = "QueryVoucherStatus";
        public const string QueryVoucherDeliveryStatus = "QueryVoucherDeliveryStatus";
        public const string CheckOrderStatus = "CheckOrderStatus";
        public const string GetMultiVouchers = "GetMultiVouchers";
        public const string BlockVouchers = "BlockVouchers";
        public const string UnBlockVouchers = "UnBlockVouchers";
        public const string TrashVouchers = "BlockVouchers";
        public const string GetVoucherV2 = "GetVoucherV2";
        public const string GetMultiVouchersV2 = "GetMultiVouchersV2";
        public const string QueryTransactionbyShop = "QueryTransaction4Merchant";
        public const string BatchTransaction = "DoBatchTransaction";
        public const string QueryTransactionHistorybyShop = "QueryTransactionHistoryByShop";
        public const string QueryLastRedemptionbyShop = "QueryLastRedemptionByShop";
        public const string CTBCGetVoucher = "GetVoucher";
        public const string ListProducts = "ListProducts";
        public const string GetProduct = "GetProduct";
        public const string GetProductLocation = "GetProductLocation";
        public const string GetProductDocument = "GetProductDocument";
    }


    public enum VoucherStatus : int
    {
        Issued = 1,
        Active = 2,
        Expired = 4,
        Trashed = 8,
        Blocked = 16,
        Used = 32,
        InStock = 64,
        PreIssuing = 128,
        PreIssued = 256
    }

    public enum VoucherDeliveryMethod
    {
        Sms,
        Email
    }

    public static class ResponseCode
    {
        public static string Success = "0000"; // Success
        public static string Fail = "9999"; // Fail
        public static string InvalidRequest = "MA0001"; // Invalid Request
        public static string ItemDoesntExist = "MA0002"; // Request item doesn’t exist
        public static string ActiveDateNotProvided = "MA0003"; // Active date is not provided
        public static string SendEmailFailt = "MA0004"; // Send email fail.
        public static string SendSmsFail = "MA0005"; // Send SMS fail
        public static string SendEmailAndSmsFail = "MA0006"; // Send email and SMS fail
        public static string EmailNotProvided = "MA0007"; // Email is not provided
        public static string MobileNotProvided = "MA0008"; // Mobile is not provided
        public static string ServerDateError = "MA0009"; // Server data error.
        public static string VoucherStockNotSufficient = "MA00010"; // Vouchers in stock is not sufficient
        public static string IssueVoucherFail = "MA00011"; // Issue voucher fail
        public static string EmailOrSmsTemplateMissing = "MA00012"; // Email or SMS template is missed
        public static string RequestDateRange = "MA00013"; // Request date range exceeds the maximum system date range
        public static string ItemIsEmpty = "MA00014"; // Response item is empty
        public static string ExceedMaximumVoucherQuantity = "MA00020"; // Exceed maximum system configured voucher quantity
        public static string ConsumerCodeDoesntExist = "MA00021"; // Consumer code doesn’t exist
        public static string VoucherNumberDoesntExist = "MA00022"; // Voucher number doesn’t exist
        public static string ShopDoesntExist = "MA00023"; // Shop doesn’t exist
        public static string RedeemFail = "MA00024"; // Redeem voucher fail
        public static string VoucherCantResend = "MA0025"; // Voucher cannot resend.
        public static string NoActiveAcceptanceLoop = "MA0026"; // No active acceptance loop.
        public static string PartSuccess = "MA0027"; // Part success.
        public static string InvalidAvailableQuantity = "MA0034"; // Invalid Available Quantity
    }

    public static class ParameterReggex
    {
        public const string OrderNumber = @"^20\d{2}(0[1-9]|1[0-2])(0[1-9]|[1-2]\d{1}|3[0-1])\d{4}$";
        public const string ProductCode = @"^[a-zA-Z0-9]{1,50}$";

        public static string Check(string value, string reggex)
        {
            if (value != null && value != string.Empty)
            {
                if (Regex.IsMatch(value, reggex))
                {
                    return value;
                }
                else
                {
                    throw new Exception(/*"String parameter: \"" + value + "\" does not match " + reggex*/);
                }
            }
            return null;
        }
    }
}
