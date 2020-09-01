# Entendendo Herença e Interface

### _Sobrecarga_

Sobrecarga de métodos é um riquíssimo recurso do C#. Só para lembrar, sobrecargas acontecem quando temos mais de um método com o mesmo nome e diferentes listas de argumentos, como o caso abaixo:

```

    public void EscreveNumero(int n)
    {
        Console.WriteLine("inteiro: " + n);
    }
    public void EscreveNumero(double n)
    {
        Console.WriteLine("ponto flutuante: " + n);
    }

```

Quanda duas ou mais sobrecargas são elegíveis de execução, encontraremos o erro CS0121:

> Erro CS0121: A chamada é ambígua entre os seguintes métodos ou propriedades: 'xxxx()' and 'xxxx()'

### _Sobrescrevendo métodos_



permita uma sobrescrita de sua implementação. Sendo assim, diremos que GetBonificacao() é um método virtual. Ou seja, tem implementação em Funcionario, mas por ser virtual, possibilita que uma classe filha e mais derivada, mude o comportamento desse método. Começaremos a adequação do código em Funcionario, adicionando virtual após public, na declaração de GetBonificacao().

```

public class Base
{
    public virtual void M() { … }
}

```

Ao digitarmos, veremos que a fonte de virtual está na cor azul e com a primeira letra minúscula, indicando que é uma palavra reservada. Tudo certo, o código está válido. Após estabelecermos que GetBonificacao() é um método virtual, ou seja, com implementação que pode ser sobrescrita, precisamos apontar em Diretor que GetBonificacao() não é mais um método. O GetBonificacao() de Diretor está sobrescrevendo o GetBonificacao() de Funcionario. Então, em Diretor, adicionaremos override após public, na declaração de GetBonificacao().


```

public class Derivada : Base
{
    public override void M() { … }
}

```

Adicionamos outra palavra reservada, que traduzida para o português significa sobrepor. No caso, ela informa que GetBonificacao() não é repetição do GetBonificacao() de Funcionario. O de Diretor está sobrescrevendo, sobrepondo, o comportamento estabelecido em Funcionario. Salvaremos as alterações e executaremos a aplicação para conferir se funciona

Para isso, foi necessário utilizar as palavras reservadas virtual e override, na classe base e na classe derivada,

É bem possível uma classe derivada possuir uma forma diferente de se definir ou obter uma propriedade, então, faz sentido marcar uma propriedade como virtual! Para isto, usamos o modificador após o public:

```

public virtual int Numero { get; set; }

```

Agora, na classe Derivada, podemos expandir e sobrescrever o get e o set:

```

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

```

**Nota:** em qualquer tipo de propriedade, não podemos expandir apenas o get ou apenas o set, devemos fazer isto em ambos!

    
### Base
A classe filha pode fazer referência aos membros da classe base com uso desta palavra reservada.

Note que não queremos chamar o método GetBonificacao() sobrescrito em Diretor. Queremos chamar GetBonificacao() da classe base (Funcionario). Como podemos fazer isso? Em C#, temos a palavra reservada base para fazer referência à base. A fonte da palavra ficará no formato de uma palavra reservada, em azul e com a primeira letra minúscula. Se adicionarmos a GetBonificacao(), de Diretor, e colocarmos um ponto (.) após digita-la, aparecerá uma lista de sugestão de auto-preenchimento com os membros que foram declarados na classe base, como:

CPF;
Nome;
Salario;
o mais interessante: GetBonificacao.
Sendo assim, em Diretor, acrescentaremos base. antes de GetBonificacao(), na linha de return.

```

public override double GetBonificacao()
{
    return Salario + base.GetBonificacao();
}

```

### Protected

Mas isso é correto? O ideal seria que o campo Salario pudesse ser manipulado somente dentro da classe Funcionario e a partir dos tipos derivados dela. Para isso, podemos utilizar outro modificador de acesso, protected. Ele permite, justamente, que o campo seja acessível tanto na classe base, quanto nas derivadas dela. Se estamos fora de uma delas, como em Program, não teremos acesso a Salario. Então, ele está protegido dentro da classe base e suas filhas.

Agora que adicionamos o modificador de acesso protected, conseguimos acessar tanto da classe Funcionario, quanto da classe derivada Diretor.

### Modificadores
A ordem dos modificadores de visibilidade, da menor visibilidade para a maior:

> private < protected < public

 1. _private_ - apenas visível dentro da classe; 
 2. _protected_ - visível dentro da classe e também para as filhas; protected é relacionado com a herança.
 3. _public_ - visível em todo lugar; 

### Classes abstratas
Uma classe abstrata representa um conceito, algo abstrato, e o compilador não permite instanciar um objeto dessa classe. Para instanciar é preciso criar primeiro uma classe filha não abstrata.

### Métodos abstratos
 Métodos abstratos só podem fazer parte de classes abstratas. 
 Um método abstrato não possui corpo (implementação), define apenas a assinatura (visibilidade, retorno, nome do método e parâmetros). Se a classe não é abstrata, geramos um estado indefinido. Por isso, a regra de métodos abstratos somente em classes abstratas é obrigatória.

 ### Classe abstrata X Interface
O C# não aceita herança múltipla, entretanto, 
 A interface é muito semelhante à classe abstrata, que possui somente método abstrato. Na interface, a diferença é que não utilizamos modificador de visibilidade (public), nem repetimos abstract em todos os lugares, pois é uma característica de interface.
 A interface **nunca poderá ter a implementação de um método.**

 Utilizando interfaces temos uma outra forma de conseguir polimorfismo sem herança.

Ordem da herança da classe, passando primeiro a classe e, depois a interface, para resolver o erro apontado, deixando-a da seguinte forma:

> public class Exemplo : ClasseBase, IInterface
 
Por convenção se estabelece que interface deve ser prefixada com I, de interface. Assim, sempre saberemos se é uma classe ou interface.

> public interface IExemplo