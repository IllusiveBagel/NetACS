using System.Runtime.Serialization;

namespace NetACS.Models
{
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
}
