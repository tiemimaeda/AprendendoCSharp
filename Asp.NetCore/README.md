# ASP.NET Core

Em um navegador que utliza o modelo HTTP toda comunicação começa com um pedido, e quem fez o pedido fica esperando uma resposta. Só que pro navegador não interessa saber quem vai responder a ele. A única coisa que ele precisa saber é o endereço do pedido. Na especificação HTTP, esse endereço é chamado de URI.

A parte que responde uma requisição é chamada de servidor. E a parte que faz o pedido é chamada de cliente.

Termo usado pelo ASP.NET Core para representar o fluxo que uma requisição HTTP percorre dentro de sua aplicação até que a resposta seja entregue ao cliente é conhecido como _Request Pipeline_.
O código que escrevemos nesse pipeline é chamado Middleware.

### Configurando ambientes diferentes
A classe Startup é usada para realizar a inicialização do nosso servidor, mais especificamente no método Configure().

Você sabia que é possível configurar diferentes ambientes usando métodos Configure diferentes? Por convenção, o ASP.NET Core permite que você configure o ambiente de desenvolvimento através de um método ConfigureDevelopment(). O mesmo pode ser feito para o ambiente de produção com ConfigureProduction() e o de testes com ConfigureStaging().

E mais: é possível criar classes específicas para cada ambiente. Como? Usando os nomes StartupDevelopment, StartupStaging e StartupProduction

### Request e Response

* a classe HttpContext tem as propriedade Request e Response com diversas informações sobre a requisição e oportunidades de tratar a resposta
* HttpRequest tem uma propriedade Path que informa o caminho da requisição
* HttpResponse tem uma propriedade StatusCode para definir o código de retorno na resposta da requisição
* podemos tratar requisições diferentes através de métodos específicos que são capturados pelo delegate RequestDelegate

A classe HttpRequest possui várias informações sobre a requisição enviada pelo cliente, a saber:

* dados do formulário, caso exista
* dados da query string, caso exista
* dados do cabeçalho da requisição
* dados sobre cookies da requisição
* qual método HTTP foi utilizado
* se a requisição é segura ou não
* e outras!

### Método de envio da requisição

No HTTP, os mais comuns são o GET e o POST. O método padrão é o GET.

Ex: A URL 
        
        http://localhost:5000/Cadastro/NovoLivro?titulo=Inferno&autor=Dan Brown 

Indica que o método usado no formulário foi GET

Imagine que estamos em uma página de cadastro e cadastramos uma senha. Não seria nada seguro que nossa senha e usuário aparecesse na url. Portanto, em formulário o ideal é utilizarmos o método POST.

### Responsabilidades da classe Startup

Esse código disponibiliza o serviço de roteamento padrão do Asp.Net Core no servidor. Sem ele não seria possível usar tal serviço posteriormente.

        services.AddRouting();


Esse código determina que o estágio terminal do request pipeline irá tratar as rotas definidas pela coleção armazenada na variável rotas. Sem ele não seria possível tratar qualquer requisição na aplicação.

        app.UseRouter(rotas);

### MVC

Essa distinção é um padrão muito comum em aplicações web, e é chamado de MVC. Essa sigla vem de *Model*, *View*, *Controller* e a correspondência com nossas partes é a seguinte:

* a lógica de atendimento das requisições é a parte **Controller**, pois é nela que as requisições são controladas;
* as classes de negócio estão na parte **Model**, pois elas modelam a aplicação;
* classes e arquivos para tratar do HTML se encontram na parte **View**, porque elas se tornarão a parte que o usuário irá ver.

### Renderização de actions
* Um objeto da classe ViewResult representa um resultado HTML
* IActionResult é uma interface que representa o resultado de uma action.
* ViewResult implement IActionResult para representar um tipo específico de resultado
* Existem vários tipos de resultados de actions. A classe ViewResult é um deles.