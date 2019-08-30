using NetACS.CWMP.Interfaces;
using NetACS.CWMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetACS.CWMP.Services
{
    public class CWMPService : ICWMPService
    {
        public CWMPModel Inform(CWMPModel model)
        {
            Console.WriteLine("Message Recieved");
            return model;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }
    }
}
