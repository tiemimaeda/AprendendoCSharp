using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataCorrente = DateTime.Now;
            DateTime dataFimPagamento = new DateTime(2020, 12, 30);

            TimeSpan diferenca = TimeSpan.FromDays(30); //dataFimPagamento - dataCorrente;

            string mensagem = $"Vencimento em: {TimeSpanHumanizeExtensions.Humanize(diferenca)}";

            Console.WriteLine(dataCorrente);
            Console.WriteLine(dataFimPagamento);
            Console.WriteLine(mensagem);


            Console.ReadLine();
        }
    }
}
