using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CriandoVariaveisPontoFlutuante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 3 - Criando variáveis ponto flutuante");

            double salario;
            salario = 1200.70;
            Console.WriteLine(salario);

            //double admite números inteiros e decimais, depende de como vc usa
            //Se um dos números tiver decimal, o resultado será com decimal, se nenhum
            //dos números tiver decimal, o número será arredondado para inteiro
            double idade;
            idade = 15.0 / 2;
            Console.WriteLine(idade);

            Console.WriteLine("Execução finalizada. Tecle enter para sair...");
            Console.ReadLine();
        }
    }
}
