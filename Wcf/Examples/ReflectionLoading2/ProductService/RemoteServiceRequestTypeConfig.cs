using Product.Api.Common;
using Product.Api.Common.Dto;
using System;
using System.Collections.Generic;

namespace ProductService
{
    public class RemoteServiceRequestTypeConfig
    {
        private static Dictionary<string, Type> operationRequestTypesMap;
        static RemoteServiceRequestTypeConfig()
        {
            operationRequestTypesMap = new Dictionary<string, Type>();
            //operationRequestTypesMap.Add(OrderServiceOperation.CreateOrder.ToString(), typeof(CreateOrderRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.PublishOrder.ToString(), typeof(PublishOrderRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.QueryOrderStatus.ToString(), typeof(QueryOrderStatusRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.GetProductList.ToString(), typeof(GetProductListRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.GetProductDetailInfo.ToString(), typeof(GetProductDetailInfoRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.CreatePO.ToString(), typeof(CreatePurchaseOrderRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.CreateDirectOrder.ToString(), typeof(CreateDirectOrderRequest));
            //operationRequestTypesMap.Add(ProductServiceOperation.GetProductListByProgram.ToString(), typeof(GetProductByProgramCodeRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.ImportFamilyMarttVoucher.ToString(), typeof(ImportFamilyMartVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.TransferFamilyMartVoucher.ToString(), typeof(TransferFamilyMartVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetTrashVoucher.ToString(), typeof(GetTrashVoucherRequest));
            //operationRequestTypesMap.Add(TransactionServiceOperation.ImportBatchTransaction.ToString(), typeof(ImportBatchTransactionRequest));
            //operationRequestTypesMap.Add(TransactionServiceOperation.QueryBatchTransaction.ToString(), typeof(QueryBatchTransactionRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.CheckVoucherAlias.ToString(), typeof(CheckVoucherAliasRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetVoucherInfoWithPwd.ToString(), typeof(GetVoucherInfoWithPwdRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetVoucherInfoWithGuid.ToString(), typeof(GetVoucherInfoWithGuidRequest));
            //operationRequestTypesMap.Add(ProductServiceOperation.GetAliasProductInfo.ToString(), typeof(GetAliasProductInfoRequest));
            //operationRequestTypesMap.Add(ProductServiceOperation.GetProductInfoByVoucherGuid.ToString(), typeof(GetProductInfoByVoucherGuidRequest));
            //operationRequestTypesMap.Add(ProductServiceOperation.GetProductInfoByVoucherAlias.ToString(), typeof(GetProductInfoByVoucherAliasRequest));
            //operationRequestTypesMap.Add(ProductServiceOperation.GetProductAndVoucherInfoByVoucherGuid.ToString(), typeof(GetProductAndVoucherInfoByVoucherGuidRequest));
            //operationRequestTypesMap.Add(ProductServiceOperation.GetProductAndVoucherInfoByVoucherAlias.ToString(), typeof(GetProductAndVoucherInfoByVoucherAliasRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetVoucherInfoByVoucherAlias.ToString(), typeof(GetVoucherInfoByVoucherAliasRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetVoucherInfoByVoucherGuid.ToString(), typeof(GetVoucherInfoByVoucherGuidRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetVoucherLayoutInfoByVoucherGuid.ToString(), typeof(GetVoucherLayoutInfoByVoucherGuidRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetVoucherLayoutInfoByVoucherAlias.ToString(), typeof(GetVoucherLayoutInfoByVoucherAliasRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetTransactionInfoListByVoucher.ToString(), typeof(GetTransactionInfoListByVoucherRequestDto));
            //operationRequestTypesMap.Add(OrderServiceOperation.GetOrderBeneficiaryInfo.ToString(), typeof(GetOrderBeneficiaryInfoRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.CreateDirectOrderWithoutPrice.ToString(), typeof(CreateDirectOrderWithoutPriceRequest));
            //operationRequestTypesMap.Add(OrderServiceOperation.CreatePOWithoutPrice.ToString(), typeof(CreatePurchaseOrderWithoutPriceRequest));
            //operationRequestTypesMap.Add(TransactionServiceOperation.QueryTransactionHistoryByShop.ToString(), typeof(QueryTransactionHistoryByShopRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.ImportSevenElevenVoucher.ToString(), typeof(ImportSevenElevenVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.TransferSevenElevenVoucher.ToString(), typeof(TransferSevenElevenVoucherRequest));
            //operationRequestTypesMap.Add(TransactionServiceOperation.QueryTransactionByVoucherNumber.ToString(), typeof(GetTransactionInfoListByVoucherNumberRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.ImportTWVoucher.ToString(), typeof(ImportTWVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.TransferTWVoucher.ToString(), typeof(TransferTWVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.ImportIQiYiVoucher.ToString(), typeof(ImportIQiYiVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.TransferIQiYiVoucher.ToString(), typeof(TransferIQiYiVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.ImportFMBardCodeOneVoucher.ToString(), typeof(ImportFMBardCodeOneVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.TransferFMBardCodeOneVoucher.ToString(), typeof(TransferFMBardCodeOneVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.GetNeedResendVoucherListByEmail.ToString(), typeof(GetNeedResendVoucherListByEmailRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.SubscribeVoucherNotification.ToString(), typeof(VoucherNotificationSubscriptionRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.UnsubscribeVoucherNotification.ToString(), typeof(VoucherNotificationSubscriptionRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.ResendVoucher.ToString(), typeof(ResendVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.QueryVoucherStatus.ToString(), typeof(QueryVoucherStatusRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.CheckAlias.ToString(), typeof(CheckAliasRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.TransferIQiYiBarcodeOneVoucher.ToString(), typeof(TransferIQiYiBarcodeOneVoucherRequest));
            //operationRequestTypesMap.Add(VoucherServiceOperation.ImportIQiYiBarcodeOneVoucher.ToString(), typeof(BaseImportVoucherRequest));
            // TODO Add request type to dictionary. SevenEleven


            // IN
            //operationRequestTypesMap.Add(INOrderServiceOperation.INCreateOrder.ToString(), typeof(INCreateOrderRequest));
            //operationRequestTypesMap.Add(INOrderServiceOperation.INCheckOrderStatus.ToString(), typeof(INCheckOrderStatusRequest));
            //operationRequestTypesMap.Add(INOrderServiceOperation.INRepublishOrder.ToString(), typeof(INRepublishOrderRequest));
            //operationRequestTypesMap.Add(INOrderServiceOperation.INResendOrder.ToString(), typeof(INResendOrderRequest));
            //operationRequestTypesMap.Add(INOrderServiceOperation.INTrashOrder.ToString(), typeof(INTrashOrderRequest));

            //operationRequestTypesMap.Add(INProductServiceOperation.INGetProductMaster.ToString(), typeof(INGetProductMasterRequest));
            //operationRequestTypesMap.Add(INProductServiceOperation.INGetProductDetails.ToString(), typeof(INGetProductDetailsRequest));

            //operationRequestTypesMap.Add(INVoucherServiceOperation.INTrashMultiVouchers.ToString(), typeof(INTrashMultiVouchersRequest));
            //operationRequestTypesMap.Add(INVoucherServiceOperation.INResendMultiVouchers.ToString(), typeof(INResendMultiVouchersRequest));
            //operationRequestTypesMap.Add(INVoucherServiceOperation.INGetVoucherStatus.ToString(), typeof(INGetVoucherStatusRequest));

            operationRequestTypesMap.Add(ProductServiceOperation.GetListProducts.ToString(), typeof(GetListProductsRequest));
        }

        public static Type GetOperationRequestType(string operationName)
        {
            return operationRequestTypesMap[operationName];
        }
    }
}
