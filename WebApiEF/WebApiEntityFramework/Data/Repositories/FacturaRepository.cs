using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.Data.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private Facturacion_programacionContext _context;
        public FacturaRepository(Facturacion_programacionContext context) 
        {
            _context = context;
        }
       
        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Facturas
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdArticuloNavigation)
                .Include(f => f.IdFormaPagoNavigation)
                .ToListAsync();
        }
        public async Task<Factura?> GetByIdAsync(int id)
        {
            var facturaSelectionada = await _context.Facturas
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdArticuloNavigation)
                .Include(f => f.IdFormaPagoNavigation)
                .FirstOrDefaultAsync(f => f.IdFactura == id);
            return facturaSelectionada;
        }
        public async Task AddAsync(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Factura factura)
        {
            var facturaExistente = await _context.Facturas
                .Include(f => f.DetallesFacturas)
                .FirstOrDefaultAsync(f => f.IdFactura == factura.IdFactura);

            if (facturaExistente != null)
            {
                // Actualiza las propiedades principales
                facturaExistente.Fecha = factura.Fecha;
                facturaExistente.Cliente = factura.Cliente;
                facturaExistente.IdFormaPago = factura.IdFormaPago;
                facturaExistente.Activo = factura.Activo;
                facturaExistente.DetallesFacturas = factura.DetallesFacturas;
                facturaExistente.IdFormaPagoNavigation = factura.IdFormaPagoNavigation;
                
                _context.Facturas.Update(facturaExistente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
