using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Articulos_Repository
{
    public interface IArticulosRepository
    {
        List<Articulo> GetAll();
        Articulo GetById(int id); 
        void Save(Articulo articulo);
        void Update(Articulo articulo);
        void Delete(int id);
    }
}
