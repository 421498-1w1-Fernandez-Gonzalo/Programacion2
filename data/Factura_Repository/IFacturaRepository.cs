using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Factura_Repository
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura GetById(int id);
        bool Save(Factura factura);
        void Update(Factura factura);
        void Delete(int id);
    }
}
