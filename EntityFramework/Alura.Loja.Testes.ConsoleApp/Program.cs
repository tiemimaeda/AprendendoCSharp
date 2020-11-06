using Microsoft.EntityFrameworkCore;
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
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerfactory = serviceProvider.GetService<ILoggerFactory>();
                loggerfactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}"); 
               
                var produto = contexto
                    .Produtos
                    .Where(p => p.Id == 1002)
                    .FirstOrDefault();

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    .Load();

                Console.WriteLine($"Mostrando as compras do produto {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine("\t" + item);
                }

            }
        }

        private static void ExibeProdutosDaPromocao()
        {
            using (var contexto2 = new LojaContext())
            {
                var serviceProvider = contexto2.GetInfrastructure<IServiceProvider>();
                var loggerfactory = serviceProvider.GetService<ILoggerFactory>();
                loggerfactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto2
                    .Promocoes
                    .Include(p => p.Produtos) //faz um select com join
                    .ThenInclude(pp => pp.Produto) //desce mais um nível no relacionamento
                    .FirstOrDefault();

                Console.WriteLine("\nMostrando produtos da promoção...");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerfactory = serviceProvider.GetService<ILoggerFactory>();
                loggerfactory.AddProvider(SqlLoggerProvider.Create());

                //criar a promoção
                var promocao = new Promocao();
                promocao.Descricao = "Queima total Pandemia 2020";
                promocao.DataInicio = new DateTime(2020, 12, 1);
                promocao.DataTermino = new DateTime(2020, 12, 31);

                //pego produtos do banco
                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                //adiciono na promoção
                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                //adiciono no contexto
                contexto.Promocoes.Add(promocao);

                contexto.SaveChanges();
            }

            using (var contexto2 = new LojaContext())
            {
                var promocao = contexto2.Promocoes.FirstOrDefault();
                Console.WriteLine("\nMostrando produtos da promoção...");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void UmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua Aleatória",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerfactory = serviceProvider.GetService<ILoggerFactory>();
                loggerfactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();

            }
        }

        private static void MuitosParaMuitos()
        {
            var p1 = new Produto() { Nome = "Suco de laranja", Categoria = "Bebidas", PrecoUnitario = 7.50, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "kg" };
            var p3 = new Produto() { Nome = "Arroz", Categoria = "Alimentos", PrecoUnitario = 25.00, Unidade = "kg" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);


            ////compra de 6 pães franceses
            //var paoFrances = new Produto();
            //paoFrances.Nome = "Pão Francês";
            //paoFrances.PrecoUnitario = 0.40;
            //paoFrances.Unidade = "Unidade";
            //paoFrances.Categoria = "Padaria";

            //var compra = new Compra();
            //compra.Quantidade = 6;
            //compra.Produto = paoFrances;
            //compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerfactory = serviceProvider.GetService<ILoggerFactory>();
                loggerfactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Promocoes.Add(promocaoDePascoa);
                var promocao = contexto.Promocoes.Find(2);
                contexto.Promocoes.Remove(promocao);
                contexto.SaveChanges();
            }
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
