using WebApiEntityFramework.Models;

namespace WebApiEntityFramework.DTO
{
    public class FacturasDTO
    {
        public int IdFactura { get; set; }
        public DateOnly? Fecha { get; set; }
        public string Cliente { get; set; }
        public string FormaPago { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; }

        public static FacturasDTO FromModel(Factura factura)
        {
            return new FacturasDTO
            {
                IdFactura = factura.IdFactura,
                Fecha = factura.Fecha,
                Cliente = factura.Cliente,
                FormaPago = factura.IdFormaPagoNavigation?.FormaPago,
                Detalles = factura.DetallesFacturas?.Select(df => new DetalleFacturaDTO
                {
                    IdDetalleFactura = df.IdDetalleFactura,
                    Articulo = df.IdArticuloNavigation?.Nombre,
                    PrecioUnitario = df.IdArticuloNavigation?.PrecioUnitario,
                    Cantidad = df.Cantidad
                }).ToList()
            };
        }
       
        public static Factura ToModel(FacturasDTO facturaDto)
        {
            return new Factura
            {
                IdFactura = facturaDto.IdFactura,
                Fecha = facturaDto.Fecha,
                Cliente = facturaDto.Cliente,
                Activo = true,
                IdFormaPagoNavigation = new FormasPago { FormaPago = facturaDto.FormaPago },
                DetallesFacturas = facturaDto.Detalles?.Select(df => new DetallesFactura
                {
                    IdDetalleFactura = df.IdDetalleFactura,
                    Cantidad = df.Cantidad,
                    IdArticuloNavigation = new Articulo
                    {
                        Nombre = df.Articulo,
                        PrecioUnitario = df.PrecioUnitario
                    },
                    Activo = true
                }).ToList(),
                
            };
        }
    }
}
