using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data
{
    public interface IDataHelper
    {

        DataTable ExecuteSPQuery(string sp, Dictionary<string, object> parametros = null);
        int ExecuteSPNonQuery(string sp, Dictionary<string, object> parametros = null);
    }
}
