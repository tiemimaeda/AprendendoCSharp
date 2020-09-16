# String e Expressões Regulares

### _Método IndexOf_
Retorna sempre o índice da primeira ocorrência que buscamos. No .NET a contagem inicia-se no zero. O método retorna -1 caso o caractere ou a cadeia de caracteres não seja encontrada nessa instância.

        Palavra
        |||||||
        0123456

### _Método Substring_
Ao manipular strings, podemos querer pegar apenas partes dela. Por exemplo, em uma URL, os argumentos mudam conforme mudamos de página. 

O método substring recebe um argumento que é o índice do primeiro caractere que quero começar a pegar, startIndex. 

Uma característica de todos os métodos da classe String, um objeto String, é **imutável**, ou seja, o texto original jamais será alterado, é necessário guardar a informação em um novo objeto.

### _Método IsNullOrEmpty_
É um método estático que existe na classe String, na qual colocamos os argumentos que queremos verificar. Ele verifica se a string é nulla ou vazia. O retorno é True ou False.

### _string x String_
Por que é que no .NET temos string com a primeira letra em minúsculo; sendo que sabemos que é uma classe, com método estático?

Na verdade, _string_ não é nome de classe, e sim uma palavra reservada da linguagem. Acontece que esta palavra é interpretada pelo compilador como o tipo _String_, que está no .NET.

Quando usar um ou outro? Vai da sua preferência.
Exemplo de uso:
* Quando estou falando de variáveis, membros, propriedades, uso a palavra reservada, em minúsculo. 
* Quando estou acessando um método estático, porém, como IsNullOrEmpty(), prefiro usar o String, ou a palavra que for, em maiúsculo, para deixar bem claro que estou acessando um método estático de uma classe.

### _Remove(char) e Remove(char, int)_
É utilizado para remover partes de uma string. O primeiro parâmetro é o índice do primeiro caractere a ser removido. No caso do Remove com 2 argumentos, o segundo parâmetro é a quantidade de caracteres que quero remover a contar do inicial.

### _Replace(oldChar, newChar)_
Em inglês, "substituir". Segundo a documentação do .NET, o primeiro argumento é um char antigo caractere (oldChar), e o segundo é outro char, novo caractere (newChar).

### _ToUpper e ToLower_
ToUpper retorna uma cópia dessa cadeia de caracteres convertida em maiúsculas.

ToLower retorna uma cópia dessa cadeia de caracteres convertida em minúsculas.

### _StartsWith, EndsWith e Contains_
* StartsWith determina se o **começo** de uma cadeia de caracteres corresponde a uma outra cadeia de caracteres.
* EndsWiith determina se o **fim** de uma cadeia de caracteres corresponde a uma cadeia de caracteres especificada.
* Contains determina se uma cadeia de caracteres está presente em uma cadeia de caracteres especificada.

### _Regex_
> using System.Text.RegularExpressions

Esta classe possui um método estático bastante interessante para nós — o IsMatch() —, para verificar se uma string qualquer contém o padrão que buscamos, e se ela combina com o padrão buscado (retorna True ou False).

O método Match(), é capaz de retornar um objeto que define as propriedades do texto que encontramos, que respeita este padrão e é encontrado no texto original. Assim, o guardaremos em uma variável do tipo Match, e se colocarmos .Value, obteremos exatamente o texto que passou pelo Match.

### _Classe Object_
Object, que se encontra no topo da hierarquia de todas as classes do C#, já que nesta linguagem todas as outras derivam dela. 