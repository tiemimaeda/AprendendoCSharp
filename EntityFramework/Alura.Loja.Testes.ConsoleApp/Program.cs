﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            var p1 = new Produto() { Nome = "Suco de laranja", Categoria = "Bebidas", PrecoUnitario = 7.50, Unidade = "Litros"};
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
