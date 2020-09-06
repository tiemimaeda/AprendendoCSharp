# Exceções

### _Try e Catch_
Podemos tratar erros com uso de 'if', porém, seria necessário mexer em muitas partes do código.
No C#  podemos lidar com este tipo de problema por meio das palavras reservadas **try** e **catch**.

O bloco try pode acompanhar vários blocos catch.

A CLR (máquina virtual) visita os blocos catch em ordem, de cima para baixo. Por esta razão, os tipos de exceção mais específicos devem estar no começo.

### _Classe Exception_
As exceções são representadas por objetos e duas propriedades importantes são a **Message** e **StackTrace**.

O tipo mais genérico das 'Exceptions' consegue lidar com os mais específicos graças ao polimorfismo. No .NET, todas as exceções derivam de Exception, sem ressalvas.

### _Throw_
Quando há uma exceção e, em vez de tratá-la, podemos passá-la para o próximo método da pilha de chamadas, até que atinja aquele que possui o tratamento adequado. Para isso, utilizaremos a palavra reservada **throw** (em português, "lançar") dentro do bloco catch.

Ao colocarmos throw, o compilador deixa de identificar um erro no bloco e passa adiante, pois trata-se de um controle de fluxo. Ou seja, sai do método. Isso significa, também, que qualquer código que escrevermos abaixo de throw não será executado, porque ele indica o encerramento do método.

**Nota:**  a convenção é utilizar o nome e ou ex para as variáveis de exceção capturadas nos blocos catch. 

Existem duas formas de lançar exceções no C#. Quando estamos em um catch, podemos lançar com a instrução "throw;"; mas podemos também lançar com "throw `<objeto de exception>`;" (seja em um catch ou fora dele).

O StackTrace começa quando lançamos a exceção com throw `<objeto de exception>`;. Desta forma, se usamos esta sintaxe em blocos catch, estaremos perdendo informações da exceção original.

### _*Convenções e Boas práticas_

* Construtor sem parâmetros: é uma convenção no .NET a criação do construtor sem argumentos para os tipos de exceções.
* Construtor com parâmetro de mensagem: deste modo, podemos definir uma mensagem para a exceção.
* Construtor com innerException: uma exceção interna, representa o local onde houve o erro original;
* Sufixo Exception no nome da classe: fica fácil saber que a classe é de um tipo de exceção.

        public class ExemploDeException : Exception
        {
            public ExemploDeException()
            {
                //construtor sem parâmetro
            }

            public ExemploDeException(string mensagem)
                : base(mensagem)
            {
                //construtor com parâmetro
            }

            public ExemploDeException(string mensagem, Exception excecaoInterna)
                : base(mensagem, excecaoInterna)
            {
                //construtor com innerException
            }
        }

###  _Finally_
Há um terceiro bloco, sem ser o try nem o catch, que se chama **finally**. Ele _sempre_ é executado, independentemente da ocorrência ou não de uma exceção. Pode-se usar try, catch e finally, mas é comum utilizar try e catch ou try e finally.

Para usarmos o bloco using com o código 

    using (RecursoDoSistema recurso = new RecursoDoSistema()) 
        { … }

é necessário que o RecursoDoSistema implemente a interface IDisposable.

O _using_ é um açúcar sintático para o código:

        RecursoDoSistema recurso = null;
        try
        {
            recurso = new RecursoDoSistema();
            recurso.Usar();
        }
        finally
        {
            if(recurso != null)
            {
                recurso.Dispose();
            }
        }

