using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio_unitario { get; set; }
        public int Activo { get; set; } = 1;


        public Articulo() { }

        public Articulo(int codigo, string nombre, double precio_unitario, int activo)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio_unitario = precio_unitario;
            Activo = activo;
        }

        public override string ToString()
        {
            return $"Codigo: {Codigo}, Nombre: {Nombre}, Precio Unitario: {Precio_unitario}";
        }
    }
}
