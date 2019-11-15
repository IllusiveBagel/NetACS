using System;
using System.Collections.Generic;
using System.Text;

namespace NetACS.Database.Interfaces
{
    public interface IDatabase
    {
        // Select Methods
        public List<T> Select<T>();
        public List<T> Select<T>(T model);
        public List<T> Select<T>(int count);
        public List<T> Select<T>(T model, int count);

        // Insert Methods
        public int Insert<T>(List<T> model);

        // Update Methods
        public int Update<T>(List<T> model);

        // Universal Methods
        public void Initialize(string connectionString);
        public IEnumerable<T> Query<T>(string sql); // Queries that return Data
        public int Execute(string sql); // Queries that return number of rows effected
    }
}
