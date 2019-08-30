using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NetACS.CWMP.Models
{
    [DataContract]
    public class CWMPModel
    {
        [DataMember]
        public DeviceId DeviceId { get; set; }

        [DataMember]
        public string CurrentTime { get; set; }
    }

    public class DeviceId
    {
        public string Manufacturer { get; set; }
    }
}
