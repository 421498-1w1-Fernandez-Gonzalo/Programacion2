using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Data.Articulos_Repository;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Services
{
    public class ArticuloService
    {
        private readonly IArticulosRepository _articulosRepository;
        public ArticuloService(IArticulosRepository articulosRepository)
        {
            _articulosRepository = articulosRepository;
        }
        public List<Articulo> GetAll()
        {
            return _articulosRepository.GetAll();
        }
        public Articulo GetById(int id)
        {
            return _articulosRepository.GetById(id);
        }
        public void Save(Articulo articulo)
        {
             _articulosRepository.Save(articulo);
        }
        public void Update(Articulo articulo)
        {
            _articulosRepository.Update(articulo);
        }
        public void DeleteById(int id)
        {
            _articulosRepository.Delete(id);
        }
    }
}
