using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Detalle_factura_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Services
{
    public class DetalleFacturaService
    {
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;
        public DetalleFacturaService(IDetalleFacturaRepository detalleFacturaRepository)
        {
            _detalleFacturaRepository = detalleFacturaRepository;
        }
        public List<Detalle_factura> GetAll()
        {
            return _detalleFacturaRepository.GetAll();
        }
        public List<Detalle_factura> GetById(int id)
        {
            return _detalleFacturaRepository.GetById(id);
        }
        public void Save(Detalle_factura detalleFactura)
        {
            _detalleFacturaRepository.Save(detalleFactura);
        }
        public void Update(Domain.Detalle_factura detalleFactura)
        {
            _detalleFacturaRepository.Update(detalleFactura);
        }
        public void DeleteById(int id)
        {
            _detalleFacturaRepository.Delete(id);
        }
    }
}
