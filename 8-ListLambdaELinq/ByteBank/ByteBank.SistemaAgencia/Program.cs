using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.SistemaAgencia.Extensoes;
using ByteBank.SistemaAgencia.Comparadores;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(352, 54710),
                null,
                new ContaCorrente(353, 32710),
                null,
                new ContaCorrente(330, 94521),
                new ContaCorrente(211, 14526),

            };

            //contas.Sort(); chamar a implementação dada em IComparable

            //contas.Sort(new ComparadorContaCorrentePorAgencia());

            //IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas.OrderBy(conta => conta.Numero);

            //var listaSemNulos = new List<ContaCorrente>();

            //foreach (var conta in contas)
            //{
            //    if(conta != null)
            //    {
            //        listaSemNulos.Add(conta);
            //    }
            //}

            //IEnumerable<ContaCorrente> contasNaoNulas = 
            //    contas.Where(conta => conta != null);

            //IOrderedEnumerable<ContaCorrente> contasOrdenadas =
            //    contasNaoNulas.OrderBy(conta => conta.Numero);
            //é o mesmo que:

            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }


            Console.ReadLine();
        }

        static void TestaSort()
        {
            var nomes = new List<string>()
            {
                "Tiemi",
                "Maria",
                "Carlos",
                "André"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }


            var idades = new List<int>();

            idades.Add(5);
            idades.Add(20);
            idades.Add(35);
            idades.Add(19);
            idades.Add(9);
            idades.Add(71);

            idades.AdicionarVarios(45, 67, 23, 11);
            //ListExtensoes.AdicionarVarios(idades, 45, 67, 23, 11);

            idades.AdicionarVarios(99, -1);

            idades.Sort();


            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();
            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(8);
            listaDeIdades.AdicionarVarios(50, 35, 26, 18);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no índice {i}: {idade}");
            }

        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

        ContaCorrente contaDaLulu = new ContaCorrente(11111, 2222222);

        ContaCorrente[] contas = new ContaCorrente[]
        {
                contaDaLulu,
                new ContaCorrente(874, 678543),
                new ContaCorrente(463, 142897)
        };

        lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDaLulu,
                new ContaCorrente(874, 678543),
                new ContaCorrente(874, 678543),
                new ContaCorrente(874, 678543),
                new ContaCorrente(874, 678543)
                );

            for (int i = 0; i<lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
        Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }

}

        static void TestaArrayDeContaCorrente()
            {
                ContaCorrente[] contas = new ContaCorrente[]
               {
                    new ContaCorrente(874, 678543),
                    new ContaCorrente(463, 142897),
                    new ContaCorrente(562, 984712)
               };

                for (int indice = 0; indice < contas.Length; indice++)
                {
                    Console.WriteLine($"Conta {indice} {contas[indice].Numero}");
                }

            }

        static void TestaArrayInt()
        {
            //Array de inteiros com 5 posições:
            int[] idades = new int[6];

            idades[0] = 02;
            idades[1] = 10;
            idades[2] = 24;
            idades[3] = 35;
            idades[4] = 50;
            idades[5] = 21;

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;

            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }
    }
}
