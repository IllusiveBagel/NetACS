using System;
using System.Collections.Generic;
using System.Text;

namespace NetACS.Database.Interfaces
{
    public interface IDatabase
    {
        public List<T> Select<T>();
        public List<T> Select<T>(T model);
        public List<T> Select<T>(int count);
        public List<T> Select<T>(T model, int count);
        public bool Insert<T>(List<T> model);
        public bool Update<T>(List<T> model);
    }
}
