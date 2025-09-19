using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.Services
{
    public interface IFacturasService
    {
        Task<IEnumerable<Factura>> GetAllAsync();
        Task<Factura?> GetByIdAsync(int id);
        Task AddAsync(Factura factura);
        Task UpdateAsync(Factura factura);
    }
}
