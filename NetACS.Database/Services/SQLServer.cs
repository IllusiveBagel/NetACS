using System;
using System.Collections.Generic;
using System.Text;

using NetACS.Database.Interfaces;

namespace NetACS.Database.Services
{
    public class SQLServer : IDatabase
    {
        public List<T> Select<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> Select<T>(T model)
        {
            throw new NotImplementedException();
        }

        public List<T> Select<T>(int count)
        {
            throw new NotImplementedException();
        }

        public List<T> Select<T>(T model, int count)
        {
            throw new NotImplementedException();
        }

        public bool Insert<T>(List<T> model)
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(List<T> model)
        {
            throw new NotImplementedException();
        }
    }
}
