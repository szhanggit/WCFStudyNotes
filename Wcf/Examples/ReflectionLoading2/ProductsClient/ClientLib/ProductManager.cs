using Product.Api.Common;
using Product.Api.Common.Dto;
using ProductUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClient.ClientLib
{
    public class ProductManager : ClientBase
    {
        public ProductManager(){}

        public GetListProductsResponse GetListProducts(GetListProductsRequest getListProductsRequest)
        {
            if (getListProductsRequest.CheckValid() != null)
            {
                throw new ApiException(ApiResponseCode.InvalidRequest);
            }

            string responseMessage = this.Invoke(VoucherServiceOperation.GetListProducts.ToString(), getListProductsRequest);            
            return this.DeserializeResponse(typeof(GetListProductsResponse), DesHelper.Decrypt(responseMessage, ApiConsts.SecurityKey)) as GetListProductsResponse;
        }
    }
}
