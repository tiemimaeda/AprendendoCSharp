using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_AtribuicoesDeVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 6 - Atribuições de Variáveis");

            int idade = 32;
            int idadeGustavo = idade;

            idade = 20;

            //retorna 20 pq a variável idade recebeu outro valor
            Console.WriteLine(idade);

            //retorna 32 pq recebeu o primeiro valor de idade e o C# não faz referência ao que aconteceu depois da atribuição
            Console.WriteLine(idadeGustavo);

            Console.ReadLine();
        }
    }
}
