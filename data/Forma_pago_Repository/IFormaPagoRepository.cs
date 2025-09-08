using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Forma_pago_Repository
{
    public interface IFormaPagoRepository
    {
        List<Forma_pago> GetAll();
        Forma_pago GetById(int id);
        void Save(Forma_pago formaPago);
        void Update(Forma_pago formaPago);
        void Delete(int id);
    }
}
