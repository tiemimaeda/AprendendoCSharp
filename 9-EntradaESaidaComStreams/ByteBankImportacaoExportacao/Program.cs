using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // IO = Input e Output


namespace ByteBankImportacaoExportacao 
{ 
    partial class Program 
    { 
        static void Main(string[] args) 
        {
            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");
            Console.WriteLine("Arquivo escrevendoComAClasseFile criado!");

            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);
            Console.ReadLine();

            Console.WriteLine("Digite seu nome:");
            var nome = Console.ReadLine();

            Console.WriteLine(nome);


            UsarStreamDeEntrada();

            Console.WriteLine("Aplicação finalizada...");
                        
            Console.ReadLine();
        }

    }
} 
 