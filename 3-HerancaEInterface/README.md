# Entendendo Herença e Interface

### _Sobrecarga_
Sobrecarga de métodos é um riquíssimo recurso do C#. Elas acontecem quando temos mais de um método com o mesmo nome e diferentes listas de argumentos, como o caso abaixo:

    public void EscreveNumero(int n)
    {
        Console.WriteLine("inteiro: " + n);
    }
    public void EscreveNumero(double n)
    {
        Console.WriteLine("ponto flutuante: " + n);
    }

Quanda duas ou mais sobrecargas são elegíveis de execução, encontraremos o erro CS0121:

> Erro CS0121: A chamada é ambígua entre os seguintes métodos ou propriedades: 'xxxx()' and 'xxxx()'

### _Sobrescrevendo métodos_
Quando queremos permitir uma sobrescrita de sua implementação dizemos que é um método **virtual**. Ou seja, tem implementação em uma classe base, mas por ser virtual, possibilita que uma classe filha e mais derivada, mude o comportamento desse método. 

    public class Base
    {
        public virtual void M() { … }
    }

Após estabelecer que um método é virtual, ou seja, com implementação que pode ser sobrescrita, é necessário apontar na classe filha que tal método deve sobrescrever o método da classe base, para isso, adicionamos **override** após public, na declaração de GetBonificacao().

    public class Derivada : Base
    {
        public override void M() { … }
    }

É bem possível uma classe derivada possuir uma forma diferente de se definir ou obter uma propriedade, então, faz sentido marcar uma propriedade como virtual. Para isto, usamos o modificador após o public:

    public virtual int Numero { get; set; }

Agora, na classe Derivada, podemos expandir e sobrescrever o get e o set:

    public override int Numero
    {
        get
        {
            // Esse get é diferente
            // pode vir de um cache, do banco de dados, ou outro lugar.
        }
        set
        {
            // Esse set é diferente
            // pode criar um log, executar uma verificação, ou lançar um erro.
        }
    }

**Nota:** em qualquer tipo de propriedade, não podemos expandir apenas o get ou apenas o set, devemos fazer isto em ambos!

### _Base_
A classe filha pode fazer referência aos membros da classe base com uso desta palavra reservada.

Se adicionarmos a um método() um ponto (.) após digita-la, aparecerá uma lista de sugestão de auto-preenchimento com os membros que foram declarados na classe base. Ex:

    public override void Método()
    {
        return Algumacoisa + base.MembroDaClasseBase();
    }

### _Modificadores de Visibilidade_
A ordem dos modificadores de visibilidade, da menor visibilidade para a maior:

> private < protected < public

 1. _private_ - apenas visível dentro da classe; 
 2. _protected_ - visível dentro da classe base e também para as filhas; protected é relacionado com a herança.
 3. _public_ - visível em todo lugar; 

### Classes abstratas
Uma classe abstrata representa um conceito, algo abstrato, e o compilador não permite instanciar um objeto dessa classe. Para instanciar é preciso criar primeiro uma classe filha não abstrata.

### Métodos abstratos
Métodos abstratos só podem fazer parte de classes abstratas. 
Um método abstrato não possui corpo (implementação), define apenas a assinatura (visibilidade, retorno, nome do método e parâmetros). Se a classe não é abstrata, geramos um estado indefinido. Por isso, a regra de métodos abstratos somente em classes abstratas é obrigatória.

### Interface
A interface _nunca poderá ter a implementação de um método._

Utilizando interfaces temos uma outra forma de conseguir polimorfismo sem herança.

Ordem da herança da classe: primeiro a classe, depois a interface:

    public class Exemplo : ClasseBase, IInterface
 
Por convenção se estabelece que interface deve ser prefixada com **I**, de interface. Assim, sempre saberemos se é uma classe ou interface.

    public interface IExemplo

### Classe abstrata X Interface
A interface é muito semelhante à classe abstrata, que possui somente método abstrato. A diferença é que na interface não utilizamos modificador de visibilidade (public), nem repetimos abstract em todos os lugares, pois é uma característica de interface.