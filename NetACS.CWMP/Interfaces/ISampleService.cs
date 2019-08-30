using NetACS.CWMP.Models;
using System.ServiceModel;

namespace NetACS.CWMP.Interfaces
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        string Test(string s);

        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);

        [OperationContract]
        CustomModel TestCustomModel(CustomModel inputModel);
    }
}
