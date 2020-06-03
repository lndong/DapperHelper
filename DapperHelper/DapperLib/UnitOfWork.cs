using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace DapperLib
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // private readonly ILogger<UnitOfWork> _logger;
        public UnitOfWork(DatabaseConfig conn /*, ILogger<UnitOfWork> logger*/)
        {
            _connection = new SqlConnection(conn.ConnectString);
            // _connection.Open();
            // _logger = logger;
        }

        private readonly IDbConnection _connection = null;
        private IDbTransaction _transaction = null;


        // public IDbConnection Connection => _connection;

        public IDbConnection Connection
        {
            get
            {
                if (_connection != null && _connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public IDbTransaction Transaction => _transaction;

        public void Begin()
        {
            _transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            TransactionDispose();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            TransactionDispose();
        }

        public void TransactionDispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}