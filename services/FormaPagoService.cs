using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Forma_pago_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Services
{
    public class FormaPagoService
    {
        private readonly IFormaPagoRepository _formaPagoRepository;
        public FormaPagoService(IFormaPagoRepository formaPagoRepository)
        {
            _formaPagoRepository = formaPagoRepository;
        }
        public List<Forma_pago> GetAll()
        {
            return _formaPagoRepository.GetAll();
        }
        public Forma_pago GetById(int id)
        {
            return _formaPagoRepository.GetById(id);
        }
        public void Save(Forma_pago  formaPago)
        {
             _formaPagoRepository.Save(formaPago);
        }
        public void Update(Forma_pago formaPago)
        {
            _formaPagoRepository.Update(formaPago);
        }
        public void DeleteById(int id)
        {
            _formaPagoRepository.Delete(id);
        }
    }
}
