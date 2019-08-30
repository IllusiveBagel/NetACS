using NetACS.CWMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetACS.CWMP.Interfaces
{
    [ServiceContract(Namespace = "urn:dslforum-org:cwmp-1-0")]
    public interface ICWMPService
    {
        [OperationContract]
        CWMPModel Inform(CWMPModel model);

        void XmlMethod(XElement xml);
    }
}
