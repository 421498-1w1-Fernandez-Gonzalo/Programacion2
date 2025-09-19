using WebApiEntityFramework.Data.Repositories;
using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.Services
{
    public class ArticulosService: IArticulosService
    {
        private readonly IArticuloRepository _articulosRepository;
        public ArticulosService(IArticuloRepository articuloRepository) 
        {
            _articulosRepository = articuloRepository;

        }
        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return await _articulosRepository.GetAllAsync();
        }
        public async Task<Articulo?> GetByIdAsync(int id)
        {
            return await _articulosRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Articulo articulo)
        {
            await _articulosRepository.AddAsync(articulo);
        }
        public async Task UpdateAsync(Articulo articulo)
        {
            await _articulosRepository.UpdateAsync(articulo);
        }
        public async Task DeleteAsync(int id)
        {
            await _articulosRepository.DeleteAsync(id);
        }
    }
}
