using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace stackPrometeo.Data.Library
{
    public class DbConnection
    {
        private readonly SqlDatabase _database;

        public DbConnection(string connectionString)
        {
            _database = new SqlDatabase(connectionString);
        }

        public void Execute(string storedProcedure, params object[] arguments)
        {
            _database.ExecuteNonQuery(storedProcedure, arguments);
        }

        public T GetSingle<T>(string storedProcedure, Func<IDataReader, T> builder, params object[] arguments) where T : class
        {
            using (var reader = _database.ExecuteReader(storedProcedure, arguments))
            {
                if (reader.Read())
                    return builder(reader);
            }

            return null;
        }

        public List<T> GetList<T>(string storedProcedure, Func<IDataReader, T> builder, params object[] arguments) where T : class
        {
            using (var reader = _database.ExecuteReader(storedProcedure, arguments))
            {
                List<T> list = new List<T>();

                while (reader.Read())
                {
                    list.Add(builder(reader));
                }

                return list;
            }
        }

        public List<T> GetScalarList<T>(string storedProcedure, Func<IDataReader, T> builder, params object[] arguments)
        {
            using (var reader = _database.ExecuteReader(storedProcedure, arguments))
            {
                List<T> list = new List<T>();

                while (reader.Read())
                {
                    list.Add(builder(reader));
                }

                return list;
            }
        }


        public T GetScalar<T>(string storedProcedure, params object[] arguments)
        {
            return (T)_database.ExecuteScalar(storedProcedure, arguments);
        }

        /*
        public ListAndOutParameters<T> GetListAndOutParameters<T>(string storedProcedure, Func<IDataReader, T> builder,
                                               params object[] arguments) where T : class
        {
            using (var command = _database.GetStoredProcCommand(storedProcedure, arguments))
            {

                List<T> list = new List<T>();

                using (var reader = _database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        list.Add(builder(reader));
                    }
                }

                var collection = GetOutParameterCollection(command);

                ListAndOutParameters<T> result = new ListAndOutParameters<T>(list, collection);

                return result;
            }

        }

        public SingleAndOutParameters<T> GetSingleAndOutParameters<T>(string storedProcedure, Func<IDataReader, T> builder,
                                               params object[] arguments) where T : class
        {
            using (var command = _database.GetStoredProcCommand(storedProcedure, arguments))
            {

                T entity = null;

                using (var reader = _database.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        entity = builder(reader);
                    }
                }

                var collection = GetOutParameterCollection(command);

                SingleAndOutParameters<T> result = new SingleAndOutParameters<T>(entity, collection);

                return result;
            }

        }

        public ScalarAndOutParameters<T> GetScalarAndOutParameters<T>(string storedProcedure, params object[] arguments)
        {
            using (var command = _database.GetStoredProcCommand(storedProcedure, arguments))
            {
                var value = (T)_database.ExecuteScalar(command);

                var collection = GetOutParameterCollection(command);

                ScalarAndOutParameters<T> result = new ScalarAndOutParameters<T>(value, collection);

                return result;
            }
        }

        private static OutParameterCollection GetOutParameterCollection(DbCommand command)
        {
            OutParameterCollection collection = new OutParameterCollection();

            foreach (DbParameter p in command.Parameters)
            {
                if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput)
                {
                    collection.Add(p.ParameterName, p.Value);
                }
            }
            return collection;
        }


        public List<T> GetScalarList<T>(string storedProcedure, params object[] arguments)
        {
            using (IDataReader reader = _database.ExecuteReader(storedProcedure, arguments))
            {
                List<T> scalars = new List<T>();
                while (reader.Read())
                {
                    scalars.Add((T)reader[0]);
                }

                return scalars;
            }
        }*/
    }
}
