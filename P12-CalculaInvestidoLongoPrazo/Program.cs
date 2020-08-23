using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12_CalculaInvestidoLongoPrazo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 12 - Calcular Poupança Longo Prazo");

            double valorInvestido = 1000;
            double fatorRendimento = 1.0036;
            
            //laço for para contagem dos anos
            for(int contadorAno = 1; contadorAno <= 5; contadorAno++)
            {
                //for encadeado para contagem dos meses
                for(int contadorMes = 1; contadorMes <= 12; contadorMes++)
                {
                    valorInvestido *= fatorRendimento; 
                }
                fatorRendimento += 0.0010;
            }

            Console.WriteLine($"Ao término do investimento, você terá R${valorInvestido}");

            Console.ReadLine();
        }
    }
}
