using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void TestandoChangeTracker()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerfactory = serviceProvider.GetService<ILoggerFactory>();
                loggerfactory.AddProvider(SqlLoggerProvider.Create());

                //faz o select
                var produtos = contexto.Produtos.ToList();

                //pega as entidades que estão dentro do contexto e exibe
                ExibeEntries(contexto.ChangeTracker.Entries());

                //adiciona um novo produto no contexto
                var novoProduto = new Produto()
                {
                    Nome = "Balde",
                    Categoria = "Limpeza",
                    PrecoUnitario = 10.00
                };
                contexto.Produtos.Add(novoProduto);

                //remover um produto do contexto
                //var p1 = produtos.First();
                //contexto.Produtos.Remove(novoProduto);

                //exibe as entidades
                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                //exibe novamente as entidades após o SaveChanges
                ExibeEntries(contexto.ChangeTracker.Entries());
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("-----------------------");

            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}
