using System;
using System.Collections.Generic;

using NetACS.Models;
using NetACS.ACS.Interfaces;
using NetACS.Database.Interfaces;

using Microsoft.Extensions.Configuration;

namespace NetACS.ACS.Services
{
    public class InformService : IInformService
    {
        private readonly IDatabase _dataService;

        public InformService(IConfiguration configuration, IDatabase dataService)
        {
            _dataService = dataService;
            _dataService.Initialize(//configuration.GetSection("Database").GetSection("ConnectionString").Value);
           "Server=localhost\\SQLEXPRESS;Database=master;Initial Catalog=NetACS;Trusted_Connection=True;");
        }

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

        public List<DeviceId> selectTest()
        {
            return _dataService.Select<DeviceId>();
        }

        public int insertTest(List<Device> device)
        {
            return _dataService.Insert<Device>(device);
        }
    }
}
