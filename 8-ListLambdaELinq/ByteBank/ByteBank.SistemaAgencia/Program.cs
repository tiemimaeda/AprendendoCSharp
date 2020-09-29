using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> idades = new List<int>();

            idades.Add(5);
            idades.Add(20);
            idades.Add(35);
            idades.Add(19);
            idades.Add(9);
            idades.Add(71);

            //ListExtensoes.AdicionarVarios(idades, 1, 90, 87, 65);

            idades.AdicionarVarios(45, 67, 23, 11);
            ListExtensoes.AdicionarVarios(idades, 45, 67, 23, 11);

            //idades.Remove(5);

            for(int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            Console.ReadLine();
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
