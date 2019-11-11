using System;
using NetACS.ACS.Models;

namespace NetACS.ACS
{
    public class InformService : IInformService
    {
        public InformModel Inform(InformModel inform)
        {
            try
            {
                Console.WriteLine(inform.DeviceId.Manufacturer);
            }
            catch
            {
                Console.WriteLine("Model Null");
            }

            return inform;
        }
    }
}
