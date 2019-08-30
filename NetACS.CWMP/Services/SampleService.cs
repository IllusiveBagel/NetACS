using NetACS.CWMP.Interfaces;
using NetACS.CWMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetACS.CWMP.Services
{
    public class SampleService : ISampleService
    {
        public string Test(string s)
        {
            Console.WriteLine("TestMethod Executed!");
            return s;
        }

        public CustomModel TestCustomModel(CustomModel inputModel)
        {
            return inputModel;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }
    }
}
