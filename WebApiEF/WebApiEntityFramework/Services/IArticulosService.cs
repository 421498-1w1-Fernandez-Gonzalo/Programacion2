using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.Services
{
    public interface IArticulosService
    {
        Task<IEnumerable<Articulo>> GetAllAsync();
        Task<Articulo?> GetByIdAsync(int id);
        Task AddAsync(Articulo articulo);
        Task UpdateAsync(Articulo articulo);
        Task DeleteAsync(int id);
    }
}
