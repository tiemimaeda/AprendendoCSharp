# List, Lambda e Linq

### List
Lista é algo muito comum. Existe uma lista, dentro do .NET

    List<T> idades = new List<T>();

Sempre que tivermos <T>, saberemos que trata-se de um tipo genérico. 

Ela possui os métodos:

* Add(): adiciona itens à lista;
* Remove(): remove itens da lista - colocar o valor a ser removido no parâmetro;
* Count(): conta quantos itens tem a lista

### Método Genérico
Quando temos um método genérico, que depende de um argumento, que também é uma classe genérica, e ambos argumentos genéricos são iguais, o compilador infere que T de List<T> é do mesmo tipo do T do método.

### var
O uso de var é denominado _Inferência de Tipo de Variável_, e é muito comum. Muitos dos códigos abertos que encontrar na sua carreira, utilizarão var.

Quando usamos var, é como se disséssemos ao compilador que queremos armazenar o nome do tipo que temos na expressão da atribuição no var.

Portanto, com var temos um código mais elegante, mais legível e sem repetição de nome de classe — inclusive das genéricas, que possuem nomes mais complicados. E o compilador entende que var refere-se ao tipo atribuído, encontrado à direita do sinal de igual (=).

        var conta = new ContaCorrente(344,56456556);

É igual a:

        ContaCorrente conta = new ContaCorrente(344,56456556);


### Método Sort
Em inglês, "ordenar" é "sort". O método Sort() ordena uma lista. Pode ser lista de int, string e também, classes. Recebe um objeto que implementa a interface IComparer<T>:

É uma interface genérica, como indica a letra T. 

       public void Sort(IComparer<T> comparer);



### IComparable

Essa interface contém somente um método, CompareTo(), que recebe object como argumento. 

      using System.Runtime.InteropServices;
      {
              ...public interface IComparable
              {
                      ...int CompareTo(object obj);
              }
      }

O contrato estabelecido por IComparable define que CompareTo() deve retornar um int.

A interface IComparable exige uma implementação do método CompareTo, que precisa ser chamado pelo algoritmo interno do método Sort() da classe List<T>.

### OrderBy
OrderBy() precisa de um objeto que implemente a interface IOrderedEnumerable<TSource>

### Expressão Lambda

Isso:

      IOrderedEnumerable<ContaCorrente> contasOrdenadas = 
          contas.OrderBy(conta => conta.Numero);

É igual a isso:

      IOrderedEnumerable<ContaCorrente> contasOrdenadas = 
          contas.OrderBy(conta => { return conta.Numero);

### IEnumerable

Podemos utilizar OrderBy() com List e com o tipo que implementa IEnumerable. Portanto, existe algo em comum entre List e IEnumerable, que permite a utilização de OrderBy().

Se navegaremos por OrderBy() para analisá-lo detalhadamente, pressionando a tecla "Ctrl" e clicando no método. De primeira, sabemos que OrderBy() é um método genérico, em função do sinal de menor (<) que aparece logo à direita dele. Além disso, é um método genérico de dois argumentos, também de tipo genérico: TSource e TKey

Na sequência, como primeiro argumento, encontramos a palavra reservada this, indicando que OrderBy() é um método de _extensão_. Além disso, é um método de extensão do tipo IEnumerable<TSource>.

Where() também é um método de extensão, que recebe IEnumerable.

Quando falamos de Where() e OrderBy(), estamos falando de Linq, nome da tecnologia da biblioteca criada pela Microsoft, para utilizarmos essas ordenações, por meio de métodos de extensão.


