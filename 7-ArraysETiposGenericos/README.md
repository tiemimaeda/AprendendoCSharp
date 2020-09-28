# Arrays e Tipos Genéricos

### Code snippet para construtor
O Visual Studio tem um code snippet chamado **ctor**. Quando escrevemos ctor e pressionamos "Tab" duas vezes, ele cria o construtor padrão (que não tem argumento) automaticamente.

### Argumentos Opcionais
        
        public ListaDeContaCorrente(int capacidadeInicial = 5)

Repare que é como se estivéssemos criando uma variável e automaticamente inicializando-a na lista de argumentos. Assim, no nosso uso da classe, não precisamos informar um valor inicial para o array.

Isso é diferente de escrever, por exemplo, uma sobrecarga de construtor que chama o construtor this com o valor 5:

        public ListaDeContaCorrente() : this(5)
        { 
        } 

Quando escrevemos o código dessa forma, o compilador irá verificar que estamos chamando um construtor sem argumentos. Como esse construtor sem argumentos existe, ele irá executar o código acima.

_**Mas qual a diferença entre esses dois métodos?**_

Quando usamos argumentos opcionais, fica bem evidente que existe uma capacidadeInicial e que o valor padrão desse argumento é 5. Já quando criamos uma nova sobrecarga, não sabemos qual é a chamada que está sendo realizada ou se é, de fato, uma chamada para um método com mais argumentos.

### Indexador
Indexador se assemelha tanto a um método como a uma propriedade. 
Os indexadores permitem que instâncias de uma classe ou struct sejam indexados como matrizes. O valor indexado pode ser definido ou recuperado sem especificar explicitamente um membro de instância ou tipo. 

Ex:

        public ContaCorrente this[int indice]
        {
        get 
        {
                return GetItemNoIndice(indice);
        }
        }


### Foreach

        for(int i = 0; i < itens.Length; i++)
        { 
                Adicionar(itens[i]);
        }

é a mesma coisa que:

        foreach(ContaCorrente conta in items) 
        { 
        } 

### Params

Um método que recebe um array marcado com params permite que criemos um array com todos os objetos que passamos para ele, sem termos que dizer quantos parâmetros exatamente estamos passando.

Ex:

        public void AdicionarVarios(params ContaCorrente[] itens)
        {
        foreach(ContaCorrente conta in itens) 
        {
                Adicionar(conta);
        }
        } 

### Tipos Genéricos
Os genéricos são essencialmente um "modelo de código" que permite aos desenvolvedores definir estruturas de dados fortemente tipadas sem se comprometer com um tipo de dados real. Por exemplo, List<T> é uma coleção genérica que pode ser declarada e usada com qualquer tipo, como List<int> , List<string> ou List<Person> .

### Null em classe genérica
Não podemos armazenar null (nulo) em uma referência de T, pois não sabemos se T é um tipo de valor, que não admite valores nulos, ou um tipo de referência, que admite null.


