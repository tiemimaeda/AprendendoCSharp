# Orientação a Objetos

### _Qual é a relação entre classes e objetos?_

Uma classe define os membros e a estrutura que os objetos deste tipo de classe devem seguir. 

Uma classe é a especificação para a criação de um objeto na memória do computador.

### _Benefícios da POO (Programação Orientada a Objetos)_

1. **Reutilização de código:**
Com POO, não precisamos repetir o código de criação dos campos da ContaCorrente, basta reutilizar a classe.

2. Organização de código:
Agora que representamos conceitos por meio de classes, encontrar e organizar o código se torna muito mais simples.

3. Com POO, cada classe possui responsabilidade única e temos apenas um lugar para fazer manutenção.

### _Métodos x Funções_
Em termos acadêmicos, é comum chamar de **função** _quando há retorno de valor_, ou seja, é do tipo Booleano. 

_Quando não há retorno_, ou seja, é do tipo void, é comum chamar de **método**.

Mas ambos estão corretos.

### _Namespace_

Não é permitido iniciar o nome de um namespace com número e incluir hífen.

Se utilizamos a classe com frequência e trabalhamos com a classe de um namespace em específico, podemos adicionar os tipos que estão definidos naquele namespace, no início do arquivo:

> using ExNamespaceX;

"Using" é uma palavra reservada, portanto a primeira letra é minúscula. Dessa forma, informamos ao compilador que estamos usando (using) as classes que estão no namespace ExNamespaceX. Quando o compilador encontra um nome de classe, que não são palavras reservadas — como int, double e bool — ele buscará em namespace, definido no início do código.

O namespace faz parte do nome completo de uma classe.
O nome completo de uma classe segue o formato:

> namespace.nome-da-classe.

### _Métodos_

O C# é bastante estrito. Se estamos falando de método, precisamos inserir parênteses (()) após o nome. Mesmo sem argumentos, eles são necessários. Sendo assim, adicionaremos parênteses e, na sequência, chaves ({}) para abrir um bloco de código. 

* Nomes de métodos são sempre ações, por isso, usar sempre _verbos no infinitivo_.

* Por convenção, sempre _iniciar com letra maiúscula_.

### _Encapsulamento_

Ao criar métodos para manipular um campo interno da classe, estamos fazendo um **encapsulamento**. 
Ex: encapsulamos um campo, que fica privado e não fica mais publicamente exposto, e o método público é quem permite acessarmos a informação do campo.

### _Propriedades_

Por convenção, sempre utilizamos as palavras em inglês _get_ (obter) e _set_ (atribuir).
Ex:
> public int Idade { get; set; }

Por trás do código public int Idade { get; set; } o compilador cria um campo privado para a idade e 2 métodos, um para o Get_Idade e outro para o Set_Idade.

**Nota:** Dentro do bloco de um get ou set, pode haver um campo com o mesmo nome da propriedade, mas com a primeira letra minúscula, que pode gerar confusão. Para evitar que isso aconteça, há uma convenção sobre mudar o nome do campo interno. Sendo assim, no adicionaremos underline (_) à frente do campo. Assim, fica bem clara a diferença. Quando avistamos o underline, sabemos que é um campo privado e pertence somente a essa classe.

### _Construtores_
* Construtores são utilizados para inicializar os atributos.
