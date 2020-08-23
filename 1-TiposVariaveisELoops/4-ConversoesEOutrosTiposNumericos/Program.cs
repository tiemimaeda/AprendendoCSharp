using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ConversoesEOutrosTiposNumericos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 4");

            double salario;
            salario = 1200.50;

            //Casting - conversão
            //neste caso, o número perde a precisão
            //int suporta 32bits
            int salarioEmInteiro;
            salarioEmInteiro = (int)salario;
            Console.WriteLine(salarioEmInteiro);

            //long suporta 64bits
            long idade = 130000000000;
            Console.WriteLine(idade);

            //short suporta 16bits
            short quantidadeProdutos = 15000;
            Console.WriteLine(quantidadeProdutos);

            //não é muito usual, mas para não ser confundido com double,
            //precisa colocar o f
            float altura = 1.80f;
            Console.WriteLine(altura);

            Console.ReadLine();

        }
    }
}
