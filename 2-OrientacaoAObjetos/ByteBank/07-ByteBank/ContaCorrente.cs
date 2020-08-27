
namespace _07_ByteBank
{
    public class ContaCorrente
    {
        //private Cliente _titular;
        //public Cliente Titular
        //{
        //    get
        //    {
        //        return _titular;
        //    }
        //    set
        //    {
        //        _titular = value;
        //    }
        //}
        
        //forma simplificada de fazer get e set quando não há nada além do próprio campo
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }


        private int _agencia;
        public int Agencia 
        {
            get
            {
                return _agencia;
            }
            set
            {
                if(value <= 0)
                {
                    return;
                }
                _agencia = value;
            }
         }
        public int Numero { get; set; }

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

        //<-----Forma mais trabalhosa de fazer get e set----->
        //public void SetSaldo(double saldo)
        //{
        //    if(saldo < 0)
        //    {
        //        return;
        //    }
        //    //this precisa ser usado para não haver colisão de nomes; esse this.saldo se refere ao campo e o outro, ao parâmetro
        //    this.saldo = saldo;
        //}

        //public double GetSaldo()
        //{
        //    return saldo;
        //}

        //Construtor Conta corrente - dessa forma obrigamos a sempre indicar a agência e o número
        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }
            else
            {
                _saldo -= valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }
            else
            {
                _saldo -= valor;
                contaDestino.Depositar(valor);
                return true;
            }
        }
    }
}
