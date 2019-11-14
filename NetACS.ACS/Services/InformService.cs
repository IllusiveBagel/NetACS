using System;

using NetACS.ACS.Models;
using NetACS.ACS.Interfaces;

namespace NetACS.ACS.Services
{
    public class InformService : IInformService
    {
        public Inform Inform(DeviceId DeviceId, EventStruct[] Event)
        {
            try
            {
                Console.WriteLine(DeviceId.Manufacturer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return new Models.Inform()
            { 
                DeviceId = DeviceId,
                Event = Event
            };
        }
    }
}
