using System;

using NetACS.Models;
using NetACS.ACS.Interfaces;

namespace NetACS.ACS.Services
{
    public class InformService : IInformService
    {
        public Inform Inform(DeviceId DeviceId, EventStruct[] Event, ParameterValueStruct[] ParameterList)
        {
            try
            {
                Console.WriteLine(DeviceId.Manufacturer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return new Inform()
            { 
                DeviceId = DeviceId,
                Event = Event,
                ParameterList = ParameterList
            };
        }
    }
}
