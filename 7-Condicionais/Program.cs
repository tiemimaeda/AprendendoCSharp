using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 7 - Laços e Condicionais");

            int idadeJoao = 16;
            int quantidadePessoas = 2;

            if (idadeJoao >= 18)
            {
                Console.WriteLine("João tem mais de 18 anos de idade");
            }
            else
            {
                if (quantidadePessoas >= 2)
                {
                    Console.WriteLine("João não tem mais de 18 anos, mas está acompanhado");
                }
                else
                {
                    Console.WriteLine("João não tem mais de 18 anos");
                }
            }

            Console.ReadLine();
        }
    }
}
