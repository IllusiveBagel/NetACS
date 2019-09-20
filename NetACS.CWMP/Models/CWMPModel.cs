using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NetACS.CWMP.Models
{
    [DataContract]
    public class Inform
    {
        //[DataMember(Order = 0, Name = "DeviceId")]
        //public DeviceId DeviceId { get; set; }
        [DataMember]
        public int MaxEnvelopes { get; set; }
    }

    [DataContract]
    public class DeviceId
    {
        [DataMember]
        public string Manufacturer { get; set; }
    }
}
