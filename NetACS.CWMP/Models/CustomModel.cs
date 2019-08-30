using System.Runtime.Serialization;

namespace NetACS.CWMP.Models
{
    [DataContract]
    public class CustomModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
