using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.Linq.Repositorio
{
    public class RepositorioCategoria
    {
        public Categoria BuscarPorCatetoria(Categoria categoria)
        {
            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();

            var categoriaRetornada = linq.Categoria.FirstOrDefault(x => x.Id == categoria.Id);

            return categoriaRetornada;
        }

        public List<Categoria> BuscarTodasAsCatetorias()
        {
            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();

            return linq.Categoria.ToList();
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();
            linq.Categoria.InsertOnSubmit(categoria);
            linq.SubmitChanges();
        }

        public void AlterarCatetoria(Categoria categoria)
        {
            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();

            var categoriaAlterar = linq.Categoria.FirstOrDefault(x => x.Id == categoria.Id);
            categoriaAlterar.Nome = categoria.Nome;

            linq.SubmitChanges();
        }

        public void RemoverCatetoria(Categoria categoria)
        {
            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();
            var categoriaAlterar = linq.Categoria.FirstOrDefault(x => x.Id == categoria.Id);
            linq.Categoria.DeleteOnSubmit(categoriaAlterar);

            linq.SubmitChanges();
        }
    }
}
