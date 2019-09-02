using NetACS.CWMP.Interfaces;
using NetACS.CWMP.Models;
using System;

namespace NetACS.CWMP.Services
{
    public class CWMPService : ICWMPService
    {
        public Inform Inform(Inform model)
        {
            if (model == null)
            {
                Console.WriteLine("Model Null");
            }
            else
            {
                Console.WriteLine(model.DeviceId.Manufacturer);
            }

            return new Inform();
        }
    }
}
