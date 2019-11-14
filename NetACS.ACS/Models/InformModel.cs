using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NetACS.ACS.Models
{
    [DataContract]
    public class Inform
    {
        [DataMember]
        public DeviceId DeviceId { get; set; }

        [DataMember]
        public EventStruct[] Event { get; set; }

        [DataMember]
        public ParameterValueStruct[] ParameterList { get; set; }
    }

    [DataContract]
    public class DeviceId
    {
        [DataMember]
        public string Manufacturer { get; set; }

        [DataMember]
        public string OUI { get; set; }

        [DataMember]
        public string ProductClass { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }
    }

    [DataContract]
    public class EventStruct
    {
        [DataMember]
        public string EventCode { get; set; }
    }

    [DataContract]
    public class ParameterValueStruct
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}
