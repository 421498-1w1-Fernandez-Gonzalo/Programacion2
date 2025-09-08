using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data
{
    public class DataHelper : IDataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;
        public DataHelper()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-QR5EERE\\SQLEXPRESS;Initial Catalog=Facturacion_programacion;Integrated Security=True;");
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable ExecuteSPQuery(string sp, Dictionary<string, object> parametros = null)
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(sp, _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sp;   

                // Agregar parámetros si existen
                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                table.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ExecuteSPQuery: " + ex.Message);
                table = null;
            }
            finally
            {
                _connection.Close();
            }
            return table;
        }
        public int ExecuteSPNonQuery(string sp, Dictionary<string, object> parametros = null)
        {
            int rowsAffected = 0;
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(sp, _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sp;
               
                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = -1;
               

            }
            finally
            {
                _connection.Close();
            }
            return rowsAffected;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
