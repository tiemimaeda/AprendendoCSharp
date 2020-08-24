using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDaGabriela = new ContaCorrente();
            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.agencia = 863;
            contaDaGabriela.numero = 863123;

            ContaCorrente contaDaGabrielaCosta = new ContaCorrente();
            contaDaGabrielaCosta.titular = "Gabriela";
            contaDaGabrielaCosta.agencia = 863;
            contaDaGabrielaCosta.numero = 863123;

            Console.WriteLine($"Igualdade de tipo de referência: {contaDaGabriela == contaDaGabrielaCosta}");
            //retorna false pq ao instanciarmos um novo objeto, fazemos referência a um objeto da memória, que não são os mesmos.


            int idade = 31;
            int idadeMaisUmaVez = 31;

            Console.WriteLine($"Igualdade de tipo de valor: {idade == idadeMaisUmaVez}");
            //retorna true pq eles tem valores que foram atribuídos e não uma nova instância.

            contaDaGabriela = contaDaGabrielaCosta;
            Console.WriteLine($"Igualdade de tipo de referência: {contaDaGabriela == contaDaGabrielaCosta}");
            //retorna true pq agora elas fazem referência ao mesmo objeto na memória.

            Console.ReadLine();
        }
    }
}
