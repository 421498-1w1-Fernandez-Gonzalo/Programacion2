using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Factura_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Services
{
    public class FacturasService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        public FacturasService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }
        public List<Factura> GetAll()
        {
            return _facturaRepository.GetAll();
        }
        public Factura GetById(int id)
        {
            return _facturaRepository.GetById(id);
        }
        public bool Save(Factura factura)
        {
            return _facturaRepository.Save(factura);
        }
        public void Update(Factura factura)
        {
            _facturaRepository.Update(factura);
        }
        public void Delete(int id)
        {
            _facturaRepository.Delete(id);
        }
    }
}
