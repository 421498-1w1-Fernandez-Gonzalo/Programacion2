using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.Data.Repositories
{
    public class ArticulosRepository : IArticuloRepository
    {
        private readonly Facturacion_programacionContext _context;
        public ArticulosRepository(Facturacion_programacionContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return await _context.Articulos.ToListAsync();
        }
        public async Task<Articulo?> GetByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }
        public async Task AddAsync(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Articulo articulo)
        {
            _context.Entry(articulo).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
