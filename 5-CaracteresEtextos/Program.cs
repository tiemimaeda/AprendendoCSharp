using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_CaracteresEtextos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 5 - Caracteres e Textos");

            //character - só aceita aspas simples pq é 1 caractere
            //o espaço tb é considerado caractere
            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);

            //tabela ASCII 65=A
            primeiraLetra = (char)65;
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)(primeiraLetra + 1);
            Console.WriteLine(primeiraLetra);

            string titulo = "Curso C#";
            string cursosProgramacao =
@"-.NET
- Javascript
- Java";

            Console.WriteLine(titulo);
            Console.WriteLine(cursosProgramacao);


            Console.ReadLine();

        }
    }
}
