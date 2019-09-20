using NetACS.CWMP.Interfaces;
using NetACS.CWMP.Models;
using System;

namespace NetACS.CWMP.Services
{
    public class CWMPService : ICWMPService
    {
        public string Inform(DeviceId DeviceId)
        {
            string result = "";
            if (DeviceId == null)
            {
                Console.WriteLine("Model Null");
                result = "Model Null";
            }
            else
            {
                Console.WriteLine(DeviceId.Manufacturer);
                result = "Not Null";
            }

            return result;
        }
    }
}
