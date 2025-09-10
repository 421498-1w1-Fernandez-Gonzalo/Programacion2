using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.services
{
    public interface IFacturaService
    {
        List<Factura> GetAll();
        Factura GetById(int id);
        bool Save(Factura factura);
        void Update(Factura factura);
        void Delete(int id);

    }
}
