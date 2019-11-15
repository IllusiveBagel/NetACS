using System;
using System.Collections.Generic;
using System.Text;

using NetACS.Database.Interfaces;

using Dapper;
using System.Data.SqlClient;
using System.Linq;

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
        public int Insert<T>(List<T> model)
        {
            List<string> properties = typeof(T).GetProperties().Select(property => property.Name).ToList();
            List<string> values = new List<string>();

            for (int i = 0; i < model.Count; i++)
            {
                List<string> row = new List<string>();
                foreach (string property in properties)
                {
                    row.Add($"'{typeof(T).GetProperty(property).GetValue(model[i]).ToString()}'");
                }

                values.Add(string.Join(",", row));
            }

            string data = "";

            var last = values.Last();
            foreach (string value in values)
            {
                if (value.Equals(last))
                {
                    data += $"({ value})";
                }
                else
                {
                    data += $"({value}),";
                }
            }

            return Execute(
                $"INSERT INTO {typeof(T).Name} " +
                $"({string.Join(",", properties)}) " +
                $"VALUES {data}"
            );
        }

        // Update Methods
        public int Update<T>(List<T> model)
        {
            List<string> properties = typeof(T).GetProperties().Select(property => property.Name).ToList();
            List<string> values = new List<string>();

            for (int i = 0; i < model.Count; i++)
            {
                List<string> row = new List<string>();
                foreach (string property in properties)
                {
                    row.Add($"'{typeof(T).GetProperty(property).GetValue(model[i]).ToString()}'");
                }

                values.Add(string.Join(",", row));
            }

            string data = "";

            var last = values.Last();
            foreach (string value in values)
            {
                if (value.Equals(last))
                {
                    data += $"({ value})";
                }
                else
                {
                    data += $"({value}),";
                }
            }

            return Execute(
                $"UPDATE {typeof(T).Name} " +
                $"SET {string.Join(",", properties)}" +
                $"WHERE ID=''"
            );
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
                throw new Exception("Error: Database Connection Not Initialized");
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
                throw new Exception("Error: Database Connection Not Initialized");
        }

    }
}
