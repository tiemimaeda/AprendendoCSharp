﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
           ContaCorrente contaDaGabriela = new ContaCorrente();

            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.agencia = 863;
            contaDaGabriela.numero = 863123;
            contaDaGabriela.saldo = 100;

            Console.WriteLine($@"Titular: {contaDaGabriela.titular}
Agência: {contaDaGabriela.agencia}
Número: {contaDaGabriela.numero}
Saldo: {contaDaGabriela.saldo}");
            
            Console.ReadLine();
        }
    }
}
