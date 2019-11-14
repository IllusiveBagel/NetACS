using System.Runtime.Serialization;

namespace NetACS.Models
{
    [DataContract]
    public class EventStruct
    {
        [DataMember]
        public string EventCode { get; set; }
    }
}
