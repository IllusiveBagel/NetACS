using System.Runtime.Serialization;

namespace NetACS.Models
{
    [DataContract]
    public class ParameterValueStruct
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}
