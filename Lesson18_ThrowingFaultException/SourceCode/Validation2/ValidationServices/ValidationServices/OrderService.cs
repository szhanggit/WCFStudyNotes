using OrderServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationServices
{
    [LogEndpointBehavior]
    public class OrderService : IOrdersService
    {
        public int CreateOrder(string currency, double amount)
        {
            Random rnd = new Random();
            return rnd.Next(10);
        }

        public int CreateOrderWithParametersValidation(string currency, double amount)
        {
            return CreateOrder(currency, amount);
        }

        public OrderInfo CreateOrderWithDataContractValidation(OrderData orderData)
        {
            OrderInfo info = new OrderInfo();
            info.OrderId = CreateOrder(orderData.Currency, orderData.Amount);
            return info;
        }
    }
}
