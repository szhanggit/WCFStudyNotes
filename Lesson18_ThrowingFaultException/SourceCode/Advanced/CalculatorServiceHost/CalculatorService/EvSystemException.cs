using System.Runtime.Serialization;

namespace CalculatorService
{
    [DataContract]
    public class EvSystemException
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string StackTrace { get; set; }

        [DataMember]
        public string Source { get; set; }
    }
}
