using WebApiEntityFramework.Data.Repositories;
using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.Services
{
    public class FacturasService: IFacturasService
    {
        private IFacturaRepository _facturaRepository;
        public FacturasService(IFacturaRepository facturaRepository) 
        {
            _facturaRepository = facturaRepository;
        
        }
        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _facturaRepository.GetAllAsync();
        }
        public async Task<Factura?> GetByIdAsync(int id)
        {
            return await _facturaRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Factura factura)
        {
            await _facturaRepository.AddAsync(factura);
        }
        public async Task UpdateAsync(Factura factura)
        {
            await _facturaRepository.UpdateAsync(factura);
        }



    }
}
