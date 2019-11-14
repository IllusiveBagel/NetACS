using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NetACS.Models
{
    [DataContract]
    public class DeviceId
    {
        // Used For Database Interaction Only
        public Guid ID { get; set; }

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
