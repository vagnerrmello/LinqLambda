using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.EF.Repositorio
{
    public class RepositorioProduto
    {

        public Categoria BuscarPorProduto(Produto produto)
        {
            LojaEfEntities ef = new LojaEfEntities();

            var produtoRetornada = ef.Categoria.FirstOrDefault(x => x.Id == produto.Id);

            return produtoRetornada;
        }

        public List<Produto> BuscarTodosOsProdutos()
        {
            LojaEfEntities ef = new LojaEfEntities();

            return ef.Produto.ToList();
        }

        public void AdicionarProduto(Produto produto)
        {
            try
            {
                //LojaEfEntities ef = new LojaEfEntities();

                using (var ef = new LojaEfEntities())
                {
                    produto.Categoria = ef.Categoria.FirstOrDefault(x => x.Id == produto.Categoria.Id);

                    ef.Produto.Add(produto);
                    ef.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                // Loop através de todas as entradas na coleção de erros de validação
                foreach (var entityValidationError in ex.EntityValidationErrors)
                {
                    // Obtém o nome da entidade que falhou na validação
                    string entityName = entityValidationError.Entry.Entity.GetType().Name;
                    Console.WriteLine($"A entidade '{entityName}' falhou na validação:");

                    // Loop através de todos os erros de validação para essa entidade
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        Console.WriteLine($"- A propriedade '{validationError.PropertyName}' falhou na validação. Erro: {validationError.ErrorMessage}");
                    }
                }
            }
        }

        public void AlterarProduto(Produto produto)
        {
            LojaEfEntities ef = new LojaEfEntities();

            var produtoAlterar = ef.Categoria.FirstOrDefault(x => x.Id == produto.Id);
            produtoAlterar.Nome = produto.Nome;

            int ok = ef.SaveChanges();
        }

        public void RemoverProduto(Produto produto)
        {
            LojaEfEntities ef = new LojaEfEntities();
            var produtoAlterar = ef.Categoria.FirstOrDefault(x => x.Id == produto.Id);
            ef.Categoria.Remove(produtoAlterar);

            int ok = ef.SaveChanges();
        }
    }
}
