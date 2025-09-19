using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.Data.Repositories
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAllAsync();
        Task<Factura?> GetByIdAsync(int id);
        Task AddAsync(Factura factura);
        Task UpdateAsync(Factura factura);

    }
}
