using Microsoft.Extensions.Options;
using Perfil.Infrastructure.Models;
using System;
using System.Data.SqlClient;

namespace Perfil.Infrastructure.DB
{
    public class SQLServerRepository : IDisposable
    {
        private readonly IOptions<Settings> _settings;

        private SqlConnection _connection = null;
        private string _connectionStringId;
        private string _connectionString;

        public SQLServerRepository(IOptions<Settings> settings)
        {
            _settings = settings;
            UseConnectionString(_settings.Value.SQLServerConnectionString);
        }

        public virtual string ConnnectionStringId
        {
            get
            {
                return _connectionStringId;
            }
        }

        protected SqlConnection Database
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                return _connection;
            }
        }

        public SQLServerRepository UseConnectionStringId(string connectionStringId)
        {
            _connectionStringId = connectionStringId;

            return this;
        }

        public SQLServerRepository UseConnectionString(string connectionString)
        {
            _connectionString = connectionString;

            return this;
        }

        public virtual void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
