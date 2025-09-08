using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain
{
    public class Factura
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public Forma_pago Forma_pago { get; set; }
        public string Cliente { get; set; }
        public List<Detalle_factura> Detalles { get; set; }
        public int Activo { get; set; } = 1;

        public Factura() { }

        public Factura(int codigo, DateTime fecha, string cliente, Forma_pago forma_pago, List<Detalle_factura> detalles)
        {
            Codigo = codigo;
            Fecha = fecha;
            Cliente = cliente;
            Forma_pago = forma_pago;
            Detalles = detalles;
        }
        public override string ToString()
        {
            
            return $"Codigo: {Codigo}" +
                    $" Fecha: {Fecha}" +
                    $" Cliente: {Cliente}" +
                    $" Forma de Pago: [{Forma_pago}]" +
                    $" Detalles: [{string.Join(", ", Detalles)}]";
        }
    }
}
