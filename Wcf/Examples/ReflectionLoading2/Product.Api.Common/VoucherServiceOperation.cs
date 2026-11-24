using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClient.ClientLib
{
    public enum VoucherServiceOperation
    {
        ImportFamilyMarttVoucher,
        TransferFamilyMartVoucher,
        GetTrashVoucher,
        CheckVoucherAlias,
        GetVoucherInfoWithPwd,
        GetVoucherInfoWithGuid,
        GetVoucherInfoByVoucherGuid,
        GetVoucherInfoByVoucherAlias,
        GetVoucherLayoutInfoByVoucherGuid,
        GetVoucherLayoutInfoByVoucherAlias,
        GetTransactionInfoListByVoucher,
        ImportSevenElevenVoucher,
        TransferSevenElevenVoucher,
        ImportTWVoucher,
        TransferTWVoucher,
        TransferIQiYiVoucher,
        ImportIQiYiVoucher,
        TransferFMBardCodeOneVoucher,
        ImportFMBardCodeOneVoucher,
        GetNeedResendVoucherListByEmail,
        ResendVoucher,
        SubscribeVoucherNotification,
        UnsubscribeVoucherNotification,
        TransferIQiYiBarcodeOneVoucher,
        ImportIQiYiBarcodeOneVoucher,
        QueryVoucherStatus,
        CheckAlias,
        GetComboInfoByVoucherAlias,
        GetComboInfoByVoucherGuid,
        GetComboChildByVoucherAlias,
        GetComboChildByVoucherGuid,
        ConfirmChildProduct,
        GetListProducts
    }
}
