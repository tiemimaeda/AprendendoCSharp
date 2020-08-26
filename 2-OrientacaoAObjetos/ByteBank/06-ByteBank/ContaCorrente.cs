
namespace _06_ByteBank
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
        public int Agencia { get; set; }
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
