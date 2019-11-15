using System;
using System.Runtime.Serialization;

namespace NetACS.Models
{
    [DataContract]
    public class ParameterValueStruct
    {
        public Guid ID { get; set; }

        public Guid Device { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}
