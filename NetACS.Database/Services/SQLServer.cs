using System;
using System.Collections.Generic;
using System.Text;

using NetACS.Database.Interfaces;

namespace NetACS.Database.Services
{
    public class SQLServer : IDatabase
    {
        public T Insert<T>(T model)
        {
            throw new NotImplementedException();
        }

        public T Select<T>(T model)
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T model)
        {
            throw new NotImplementedException();
        }
    }
}
