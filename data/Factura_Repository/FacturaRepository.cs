using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Articulos_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Detalle_factura_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Forma_pago_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Factura_Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private IDataHelper _dataHelper;
        public FacturaRepository(IDataHelper dataHelper) 
        {
            _dataHelper = dataHelper;
        }
        public List<Factura> GetAll()
        {
            List<Factura> lista = new List<Factura>();
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetAllFacturas");
            foreach (DataRow row in table.Rows)
            {
               
                Factura factura = new Factura
                {
                    Codigo = Convert.ToInt32(row["id_factura"]),
                    Forma_pago = new FormaPagoRepository(_dataHelper).GetById(Convert.ToInt32(row["id_forma_pago"])),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    Cliente = (string)row["cliente"],
                    Activo = Convert.ToInt32(row["Activo"])

                };
                lista.Add(factura);
            }
            return lista;
        }
        public Factura GetById(int id)
        {
            Factura factura = new Factura();
            DetalleFacturaRepository detalleFacturaRepository = new DetalleFacturaRepository(_dataHelper);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id_factura", id);   

            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetFacturaById", parameters);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                factura.Codigo = Convert.ToInt32(row["id_factura"]);
                factura.Forma_pago = new FormaPagoRepository(_dataHelper).GetById(Convert.ToInt32(row["id_forma_pago"]));
                factura.Fecha = Convert.ToDateTime(row["fecha"]);
                factura.Cliente = (string)row["cliente"];
                factura.Detalles = new List<Detalle_factura>();

                var detalles = _dataHelper.ExecuteSPQuery("sp_GetDetallesByFactura", parameters);

                foreach (DataRow d in detalles.Rows)
                {
                    Detalle_factura detalle = new Detalle_factura();
                    detalle.Codigo = Convert.ToInt32(d["id_detalle_factura"]);
                    detalle.Articulo = new ArticulosRepository(_dataHelper).GetById(Convert.ToInt32(d["id_articulo"]));
                    detalle.Factura = Convert.ToInt32(d["id_factura"]);
                    detalle.Cantidad = Convert.ToInt32(d["cantidad"]);
                    detalle.Activo = Convert.ToInt32(d["Activo"]);
                    factura.Detalles.Add(detalle);
                }

                
                factura.Activo = Convert.ToInt32(row["Activo"]);
            }
            return factura;
        }
        public bool Save(Factura factura)
        {
            bool result = true;
           
            using (var uow = new UnitOfWork())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_insertar_factura", uow.Connection, uow.Transaction);

                    if (factura.Codigo == 0)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_forma_pago", factura.Forma_pago.Codigo);
                        cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                        cmd.Parameters.AddWithValue("@cliente", factura.Cliente);
                        cmd.Parameters.AddWithValue("@activo", factura.Activo);
                        int facturaId = Convert.ToInt32(cmd.ExecuteScalar());
                        factura.Codigo = facturaId;
                        result = true;

                    }
                    else
                    {
                        cmd = new SqlCommand("sp_actualizar_factura", uow.Connection, uow.Transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_factura", factura.Codigo);
                        cmd.Parameters.AddWithValue("@id_forma_pago", factura.Forma_pago.Codigo);
                        cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                        cmd.Parameters.AddWithValue("@cliente", factura.Cliente);
                        cmd.Parameters.AddWithValue("@activo", factura.Activo);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (var detalle in factura.Detalles)
                    {
                        SqlCommand cmdDetail; 
                        if (detalle.Codigo == 0)
                        {
                            SqlCommand cmdDetalle = new SqlCommand("sp_insertar_detalle_factura", uow.Connection, uow.Transaction);
                            cmdDetalle.CommandType = CommandType.StoredProcedure;
                            cmdDetalle.Parameters.AddWithValue("@id_articulo", detalle.Articulo.Codigo);
                            cmdDetalle.Parameters.AddWithValue("@id_factura", factura.Codigo);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@activo", detalle.Activo);
                            cmdDetalle.ExecuteNonQuery();
                            

                        }
                        else
                        {
                            cmdDetail = new SqlCommand("sp_actualizar_detalle_factura", uow.Connection, uow.Transaction);
                            cmdDetail.CommandType = CommandType.StoredProcedure;
                            cmdDetail.Parameters.AddWithValue("@id_detalle_factura", detalle.Codigo);
                            cmdDetail.Parameters.AddWithValue("@id_articulo", detalle.Articulo.Codigo);
                            cmdDetail.Parameters.AddWithValue("@id_factura", factura.Codigo);
                            cmdDetail.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetail.Parameters.AddWithValue("@activo", detalle.Activo);
                            cmdDetail.ExecuteNonQuery();
                        }
                        
                    }
                    uow.Commit();


                }
                catch (Exception)
                {
                    uow.Rollback();
                    result = false;
                    Console.WriteLine("Error al guardar la factura y sus detalles.");
                }
            }
            return result;
        }
        public void Update(Factura factura)
        {
            _dataHelper.ExecuteSPNonQuery("sp_actualizar_factura", new Dictionary<string, object>
            {
                { "@id_factura", factura.Codigo },
                { "@id_forma_pago", factura.Forma_pago.Codigo },
                { "@fecha", factura.Fecha },
                { "@cliente", factura.Cliente },
                { "@activo", factura.Activo }
            });

        }
        public void Delete(int id)
        {
            _dataHelper.ExecuteSPNonQuery("sp_eliminar_factura", new Dictionary<string, object>
            {
                { "@id_factura", id },
                { "@activo", 0 }
            });
            
        }
    }
}
