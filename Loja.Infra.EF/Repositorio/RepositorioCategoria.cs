using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.EF.Repositorio
{
    public class RepositorioCategoria
    {

        public Categoria BuscarPorCatetoria(Categoria categoria)
        {
            LojaEfEntities ef = new LojaEfEntities();

            var categoriaRetornada = ef.Categoria.FirstOrDefault(x => x.Id == categoria.Id);

            return categoriaRetornada;
        }

        public List<Categoria> BuscarTodasAsCatetorias()
        {
            LojaEfEntities ef = new LojaEfEntities();

            return ef.Categoria.ToList();
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            LojaEfEntities ef = new LojaEfEntities();
            ef.Categoria.Add(categoria);
            int ok = ef.SaveChanges();

        }

        public void AlterarCatetoria(Categoria categoria)
        {
            LojaEfEntities ef = new LojaEfEntities();

            var categoriaAlterar = ef.Categoria.FirstOrDefault(x => x.Id == categoria.Id);
            categoriaAlterar.Nome = categoria.Nome;

            int ok = ef.SaveChanges();
        }

        public void RemoverCatetoria(Categoria categoria)
        {
            LojaEfEntities ef = new LojaEfEntities();
            var categoriaAlterar = ef.Categoria.FirstOrDefault(x => x.Id == categoria.Id);
            ef.Categoria.Remove(categoriaAlterar);

            int ok = ef.SaveChanges();
        }
    }
}
