using System.Runtime.Serialization;

namespace NetACS.Models
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
}
