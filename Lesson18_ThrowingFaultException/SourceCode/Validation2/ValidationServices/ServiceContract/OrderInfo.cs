using System.Runtime.Serialization;

namespace OrderServiceContract
{
    [DataContract(Name = "OrderInfo", Namespace = "http://bursteg.net/Samples/WCFIntegration/07/04")]
    public class OrderInfo
    {
        private int id;

        [DataMember(Name = "OrderID", Order = 0)]
        public int OrderId
        {
            get { return id; }
            set { id = value; }
        }

    }
}
