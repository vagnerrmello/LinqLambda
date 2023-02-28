using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //GerenciarCategoria();
            //GerenciarProduto();

            Console.ReadKey();
        }

        public static void GerenciarProduto()
        {
            Loja.Infra.EF.Produto produto = new Loja.Infra.EF.Produto();
            produto.Categoria =
                new Loja.Infra.EF.Categoria()
                { Id = 1, Nome = "Frutas" };
            produto.IdCategoria = 1;
            produto.Nome = "Melão";
            produto.Valor = 2M;

            AdicionarAlterarProdutoComEntityFramework(produto);

            Console.WriteLine("Comando executado com sucesso!");
        }

        public static void GerenciarCategoria()
        {
            //Entity Framework
            //Loja.Infra.EF.Categoria categoriaEF = new Loja.Infra.EF.Categoria();
            //categoriaEF.Id = 3;
            //categoriaEF.Nome = "Oleogenosas";
            //AdicionarAlterarCategoriaComEntityFramework(categoriaEF);
            //RemoverCategoria(categoriaEF);

            Console.WriteLine("------> Entity Framework");
            BuscarTodasAsCategoriasComEf();


            //Loja.Infra.Linq.Categoria categoriaLinq = new Loja.Infra.Linq.Categoria();
            //categoriaLinq.Id = 3;
            //categoriaLinq.Nome = "Oleogenosas";
            //AdicionarAlterarCategoriaComEntityFramework(categoriaLinq);
            //RemoverCategoria(categoriaLinq);

            Console.WriteLine("------> LINQ to SQL");
            BuscarTodasAsCategoriasComLinq();
        }

        #region EntityFrameworkCategoria
        public static void AdicionarAlterarCategoriaComEntityFramework(Loja.Infra.EF.Categoria categoria)
        {
            var categoriaExiste = new Loja.Infra.EF.Repositorio.RepositorioCategoria().BuscarPorCatetoria(categoria);

            if (categoriaExiste != null)
            {
                new Loja.Infra.EF.Repositorio.RepositorioCategoria().AlterarCatetoria(categoria);
            }
            else 
            { 
                new Loja.Infra.EF.Repositorio.RepositorioCategoria().AdicionarCategoria(categoria);
            }
        }        

        public static void RemoverCategoria(Loja.Infra.EF.Categoria categoria)
        {
            var categoriaExiste = new Loja.Infra.EF.Repositorio.RepositorioCategoria().BuscarPorCatetoria(categoria);

            if(categoriaExiste != null)
                new Loja.Infra.EF.Repositorio.RepositorioCategoria().RemoverCatetoria(categoria);
        }

        public static void BuscarTodasAsCategoriasComEf()
        {
            var categorias = new Loja.Infra.EF.Repositorio.RepositorioCategoria().BuscarTodasAsCatetorias();

            categorias.ForEach(x => Console.WriteLine(JsonConvert.SerializeObject(x)));
        }
        #endregion

        #region EntityFrameworkCategoria
        public static void AdicionarAlterarCategoriaComLinq(Loja.Infra.Linq.Categoria categoria)
        {
            var categoriaExiste = new Loja.Infra.Linq.Repositorio.RepositorioCategoria().BuscarPorCatetoria(categoria);

            if (categoriaExiste != null)
            {
                new Loja.Infra.Linq.Repositorio.RepositorioCategoria().AlterarCatetoria(categoria);
            }
            else
            {
                new Loja.Infra.Linq.Repositorio.RepositorioCategoria().AdicionarCategoria(categoria);
            }
        }

        public static void RemoverCategoriaComLinq(Loja.Infra.Linq.Categoria categoria)
        {
            var categoriaExiste = new Loja.Infra.Linq.Repositorio.RepositorioCategoria().BuscarPorCatetoria(categoria);

            if (categoriaExiste != null)
                new Loja.Infra.Linq.Repositorio.RepositorioCategoria().RemoverCatetoria(categoria);
        }

        public static void BuscarTodasAsCategoriasComLinq()
        {
            var categorias = new Loja.Infra.Linq.Repositorio.RepositorioCategoria().BuscarTodasAsCatetorias();

            categorias.ForEach(x => Console.WriteLine(JsonConvert.SerializeObject(x)));
        }
        #endregion

        #region EntityFrameworkProduto
        public static void AdicionarAlterarProdutoComEntityFramework(Loja.Infra.EF.Produto produto)
        {
            var categoriaExiste = new Loja.Infra.EF.Repositorio.RepositorioCategoria().BuscarPorCatetoria(produto.Categoria);

            if (categoriaExiste != null)
            {
                var produtoExiste = new Loja.Infra.EF.Repositorio.RepositorioProduto().BuscarPorProduto(produto);
                if (produtoExiste != null)
                {
                    new Loja.Infra.EF.Repositorio.RepositorioProduto().AlterarProduto(produto);
                }
                else
                {
                    new Loja.Infra.EF.Repositorio.RepositorioProduto().AdicionarProduto(produto);
                }
            }
            else
            {
                Console.WriteLine("Categoria não existe.");
            }
        }

        //public static void RemoverCategoria(Loja.Infra.EF.Categoria categoria)
        //{
        //    var categoriaExiste = new Loja.Infra.EF.Repositorio.RepositorioCategoria().BuscarPorCatetoria(categoria);

        //    if (categoriaExiste != null)
        //        new Loja.Infra.EF.Repositorio.RepositorioCategoria().RemoverCatetoria(categoria);
        //}

        //public static void BuscarTodasAsCategoriasComEf()
        //{
        //    var categorias = new Loja.Infra.EF.Repositorio.RepositorioCategoria().BuscarTodasAsCatetorias();

        //    categorias.ForEach(x => Console.WriteLine(JsonConvert.SerializeObject(x)));
        //}
        #endregion
    }
}
