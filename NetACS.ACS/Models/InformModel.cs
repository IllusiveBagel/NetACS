using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NetACS.ACS.Models
{
    [DataContract]
    public class InformModel
    {
        [DataMember]
        public DeviceId DeviceId { get; set; }
    }

    [DataContract]
    public class DeviceId
    {
        [DataMember]
        public string Manufacturer { get; set; }
    }
}
