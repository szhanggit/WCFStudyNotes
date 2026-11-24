using Product.Api.Common;
using Product.Api.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductInterfaces
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWCFProductService”。
    [ServiceContract]
    public interface IWCFProductService
    {
        [OperationContract]
        GetListProductsResponse GetListProducts(GetListProductsRequest request);
        [OperationContract]
        GetProductResponse GetProduct(GetProductRequest productNumber);
        [OperationContract]
        GetProductLocationResponse GetProductLocation(GetProductLocationRequest productLocation);
        [OperationContract]
        GetProductDocumentResponse GetProductDocument(GetProductDocumentRequest request);
        [OperationContract]
        [FaultContract(typeof(ApiException))]
        string Invoke(string messageId, string operationName, string requestMessage);
    }

}
