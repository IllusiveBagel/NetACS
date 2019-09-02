using System.Runtime.Serialization;

namespace NetACS.CWMP.Models
{
    [DataContract]
    public class Inform
    {
        [DataMember(Order = 0)]
        public DeviceId DeviceId { get; set; }

        [DataMember(Order = 1)]
        public string CurrentTime { get; set; }
    }

    [DataContract]
    public class DeviceId
    {
        [DataMember]
        public string Manufacturer { get; set; }
    }
}
