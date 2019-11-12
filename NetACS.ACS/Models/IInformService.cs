using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace NetACS.ACS.Models
{
    [ServiceContract(Namespace = "urn:dslforum-org:cwmp-1-0")]
    public interface IInformService
    {
        [OperationContract]
        Inform Inform(DeviceId DeviceId, Event[] Event);
    }
}
