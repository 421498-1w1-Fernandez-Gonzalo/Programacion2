using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        public UnitOfWork()
        {
            _connection = DataHelper.GetInstance().GetConnection(); 
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public SqlConnection Connection => _connection;
        public SqlTransaction Transaction => _transaction;
        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }

    }
}
