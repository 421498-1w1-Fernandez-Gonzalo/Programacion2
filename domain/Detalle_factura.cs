using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain
{
    public class Detalle_factura
    {
        public int Codigo { get; set; }

        public Articulo Articulo { get; set; }
        public int Factura { get; set; }
        public int Cantidad { get; set; }
        public int Activo { get; set; } = 1;

        public Detalle_factura() { }

        public Detalle_factura(int codigo, Articulo articulo, int factura, int cantidad, int activo)
        {
            Codigo = codigo;
            Articulo = articulo;
            Factura = factura;
            Cantidad = cantidad;
            Activo = activo;
        }
        public override string ToString()
        {
            return $"Codigo: {Codigo}, Articulo: [{Articulo}], Factura: [{Factura}], Cantidad: {Cantidad}";
        }
    }
}
