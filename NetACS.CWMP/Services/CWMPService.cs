using Microsoft.AspNetCore.Mvc;
using NetACS.CWMP.Interfaces;
using NetACS.CWMP.Models;
using System;

namespace NetACS.CWMP.Services
{
    public class CWMPService : ICWMPService
    {
        public DeviceId Inform(DeviceId inform)
        {
            try
            {
                Console.WriteLine(inform.Manufacturer);
            }
            catch
            {
                Console.WriteLine("Model Null");
            }
            
            return inform;
        }
    }
}
