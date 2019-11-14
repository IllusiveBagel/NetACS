using System.Runtime.Serialization;

namespace NetACS.ACS.Models
{
    [DataContract]
    public class Inform
    {
        [DataMember]
        public DeviceId DeviceId { get; set; }

        [DataMember]
        public EventStruct[] Event { get; set; }
    }

    [DataContract]
    public class DeviceId
    {
        [DataMember]
        public string Manufacturer { get; set; }
    }

    [DataContract]
    public class EventStruct
    {
        [DataMember]
        public string EventCode { get; set; }
    }
}
