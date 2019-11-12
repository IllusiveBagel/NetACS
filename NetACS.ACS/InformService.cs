using System;
using NetACS.ACS.Models;

namespace NetACS.ACS
{
    public class InformService : IInformService
    {
        public Inform Inform(DeviceId DeviceId, Event[] Event)
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
