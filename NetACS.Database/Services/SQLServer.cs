using System;
using System.Collections.Generic;
using System.Text;

using NetACS.Database.Interfaces;

using Dapper;
using System.Data.SqlClient;

namespace NetACS.Database.Services
{
    public class SQLServer : IDatabase
    {
        // Initialize
        public string _ConnectionString { get; private set; }
        private bool _ConnectionInitialized = false;

        public void Initialize(string connectionString)
        {
            if (_ConnectionInitialized) return;
            _ConnectionString = connectionString;
            _ConnectionInitialized = true;
        }

        // Select Methods
        public List<T> Select<T>()
        {
            return Query<T>($"SELECT * FROM {typeof(T).Name};").AsList<T>();
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

        // Insert Methods
        public bool Insert<T>(List<T> model)
        {
            var count = Execute($"INSERT INTO {typeof(T).Name} () VALUES ()");

            if (count == model.Count)
            {
                return true;
            }
            else
            {
                throw new Exception("Error: Insert Failed");
            }
        }

        // Update Methods
        public bool Update<T>(List<T> model)
        {
            throw new NotImplementedException();
        }

        // Universal Methods
        public IEnumerable<T> Query<T>(string sql)
        {
            if (_ConnectionInitialized == true)
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    conn.Open();
                    var result = conn.Query<T>(sql);
                    conn.Close();
                    return result;
                }
            }
            else
            {
                throw new Exception("Error: Database Connection Not Initialized");
            }
        }

        public int Execute(string sql)
        {
            if (_ConnectionInitialized == true)
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    conn.Open();
                    var result = conn.Execute(sql);
                    conn.Close();
                    return result;
                }
            }
            else
            {
                throw new Exception("Error: Database Connection Not Initialized");
            }
        }

    }
}
