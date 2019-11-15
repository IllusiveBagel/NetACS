using System;
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
        public int MaxEnvelopes { get; set; }

        [DataMember]
        public DateTime CurrentTime { get; set; }

        [DataMember]
        public ParameterValueStruct[] ParameterList { get; set; }
    }
}
