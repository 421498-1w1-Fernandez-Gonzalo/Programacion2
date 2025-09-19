using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.DTO
{
    public class DetalleFacturaDTO
    {
        public int IdDetalleFactura { get; set; }
        public string Articulo { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int? Cantidad { get; set; }

        public static DetalleFacturaDTO FromModel(DetallesFactura detalleFactura)
        {
            return new DetalleFacturaDTO
            {
                IdDetalleFactura = detalleFactura.IdDetalleFactura,
                Articulo = detalleFactura.IdArticuloNavigation?.Nombre,
                PrecioUnitario = detalleFactura.IdArticuloNavigation?.PrecioUnitario,
                Cantidad = detalleFactura.Cantidad
                
            };
        }
    }
}
