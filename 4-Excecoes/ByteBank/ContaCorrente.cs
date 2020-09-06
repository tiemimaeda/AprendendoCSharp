﻿// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidos { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }
       
        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0 )
            {
                ArgumentException excecao = new ArgumentException("O argumento Agência deve ser maior que zero.", nameof(agencia));
                throw excecao;
            }

            if (numero <= 0)
            {
                ArgumentException excecao = new ArgumentException("O argumento Número deve ser maior que zero.", nameof(numero));
                throw excecao;
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException e)
            {
                ContadorTransferenciasNaoPermitidos++;
                throw new OperacaoFincanceiraException("Operação não realizada", e);
            }

            contaDestino.Depositar(valor);
        }
    }
}
