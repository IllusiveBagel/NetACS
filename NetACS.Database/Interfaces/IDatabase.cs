using System;
using System.Collections.Generic;
using System.Text;

namespace NetACS.Database.Interfaces
{
    public interface IDatabase
    {
        public T Select<T>(T model);
        public T Insert<T>(T model);
        public T Update<T>(T model);
    }
}
