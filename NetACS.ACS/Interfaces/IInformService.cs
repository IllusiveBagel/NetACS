using System.ServiceModel;

using NetACS.Models;

namespace NetACS.ACS.Interfaces
{
    [ServiceContract(Namespace = "urn:dslforum-org:cwmp-1-0")]
    public interface IInformService
    {
        [OperationContract]
        Inform Inform(DeviceId DeviceId, EventStruct[] Event, ParameterValueStruct[] ParameterList);
    }
}
