using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using stackPrometeo.Data.Library;

namespace stackPrometeo.Data.Repository
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionStringName;
        private readonly DbConnection _connection;

        protected RepositoryBase(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
            _connection = CreateConnection();
        }


        private DbConnection CreateConnection()
        {
            if (ConfigurationManager.ConnectionStrings[_connectionStringName] == null)
                throw new ConfigurationErrorsException(string.Format("Connection string \"{0}\" not found", _connectionStringName));

            string connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;

            return new DbConnection(connectionString);
        }

        protected DbConnection Connection
        {
            get
            {
                return _connection;
            }
        }
    }
}
