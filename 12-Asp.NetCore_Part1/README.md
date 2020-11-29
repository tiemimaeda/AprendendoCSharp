# ASP.NETCore

### Ciclo de Vida
Quando falamos de injeção de dependência, temos que lembrar do ciclo de vida de objetos.

* **AddTransient:** serviços temporários/transitórios. A cada chamada ao método get service, é criado uma nova instância; 
* **AddScolped:** a cada requisição feita no browser, é gerado 1 instância do serviço dentro da mesma requisição;
* **AddSingleton:** cria uma instância única que vai existir durante toda a aplicação.
