using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Articulos_Repository
{
    public class ArticulosRepository : IArticulosRepository
    {
        private IDataHelper _dataHelper;

        public ArticulosRepository(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }
        public List<Articulo> GetAll()
        {
            List<Articulo> articulos = new List<Articulo>();
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetAllArticulos");
            foreach (DataRow row in table.Rows)
            {
                Articulo articulo = new Articulo
                {
                    Codigo = Convert.ToInt32(row["id_articulo"]),
                    Nombre = row["nombre"].ToString(),
                    Precio_unitario = Convert.ToDouble(row["precio_unitario"]),
                    Activo = Convert.ToInt32(row["activo"])
                };
                articulos.Add(articulo);
            }
            return articulos;
        }
        public Articulo GetById(int id)
        {

            Articulo articulo = new Articulo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@id_articulo", id);
            
            DataTable table =_dataHelper.ExecuteSPQuery("sp_GetArticuloById", parametros);
            foreach (DataRow row in table.Rows) {
                {
                    articulo.Codigo = Convert.ToInt32(row["id_articulo"]);
                    articulo.Nombre = row["nombre"].ToString();
                    articulo.Precio_unitario = Convert.ToDouble(row["precio_unitario"]);
                    articulo.Activo = Convert.ToInt32(row["Activo"]);
                };
            }
            return articulo;

        }
        public void Save(Articulo articulo)
        {
           
            _dataHelper.ExecuteSPNonQuery("sp_insertar_articulo", new Dictionary<string, object>
            {
                { "@nombre", articulo.Nombre },
                { "@precio_unitario", articulo.Precio_unitario },
                { "@activo", articulo.Activo }
            });
            
        }
        public void Update(Articulo articulo)
        {
            _dataHelper.ExecuteSPNonQuery("sp_actualizar_articulo", new Dictionary<string, object>
            {
                { "@id_articulo", articulo.Codigo },
                { "@nombre", articulo.Nombre },
                { "@precio_unitario", articulo.Precio_unitario },
                { "@activo", articulo.Activo }

            });
           
        }
        public void Delete(int id)
        {
            _dataHelper.ExecuteSPNonQuery("sp_eliminar_articulo", new Dictionary<string, object>
            {
                { "@id_articulo", id },
                { "Activo", 0 }

            });
           
        }

    }
}
