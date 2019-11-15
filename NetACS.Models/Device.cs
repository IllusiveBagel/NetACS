using System;

namespace NetACS.Models
{
    public class DeviceRead
    {
        public Guid ID { get; set; }

        public string DeviceName { get; set; }
    }

    public class Device
    {
        public string DeviceName { get; set; }
    }
}
