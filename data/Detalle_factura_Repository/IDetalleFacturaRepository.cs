using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Detalle_factura_Repository
{
    public interface IDetalleFacturaRepository
    {
        List<Detalle_factura> GetAll();
        List<Detalle_factura> GetById(int id);
        void Save(Detalle_factura detalleFactura);
        void Update(Detalle_factura detalleFactura);
        void Delete(int id);
    }
}
