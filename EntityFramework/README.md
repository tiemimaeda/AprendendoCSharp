# Entity Framework

Itens necessários para podermos utilizar o Entity Framework Core em nossos projetos:

* Entity Framework Core através do gerenciador de pacotes Nugget;
* Informar no evento de configuração do contexto o nome do banco e sua localização;
* Criar as propriedades no contexto para dizer quais classes serão persistidas;
* Criar um contexto, em geral usando a nomenclatura ModeloDoNegocioContext por convenção, que vai herdar da classe DbContext.

### **CRUD com Entity**

* Remove()
* Update()

SaveChanges() -> ss alterações só são feitas no banco depois que chamamos o método SaveChanges.


### **ChangeTracker**

Verifica se houve modificação ou não em um item do banco.
Como o ChangeTracker sabe que, quando uma propriedade foi alterada, ele deve fazer um UPDATE no banco?

O Entity guarda um snapshot dos valores dos objetos por padrão. Quando aquele objeto começa a ser monitorado pelo Entity, seja através de métodos que recuperam objetos do banco via SELECT (por exemplo ToList, First, Find, etc.), seja através do método Entry que cria uma entrada no ChangeTracker para o objeto passado como argumento do método.

### **States**

**Added**

O objeto é novo, foi adicionado ao contexto, e o método SaveChanges ainda não foi executado. Depois que as mudanças são salvas, o estado do objeto muda para Unchanged. Objetos no estado Added não têm seus valores rastreados em sua instância de EntityEntry.

**Deleted**

O objeto foi excluído do contexto. Depois que as mudanças foram salvas, seu estado muda para Detached.

**Detached**

O objeto existe, mas não está sendo monitorado. Uma entidade fica nesse estado imediatamente após ter sido criada e antes de ser adicionada ao contexto. Ela também fica nesse estado depois que foi removida do contexto através do método Detach ou se é carregada por um método com opção NoTracking. Não existem instâncias de EntityEntry associadas a objetos com esse estado.

**Modified**

Uma das propriedades escalares do objeto foi modificada e o método SaveChanges ainda não foi executado. Quando o monitoramento automático de mudanças está desligado, o estado é alterado para Modified apenas quando o método DetectChanges é chamado. Quando as mudanças são salvas, o estado do objeto muda para Unchanged.

**Unchanged**

O objeto não foi modificado desde que foi anexado ao contexto ou desde a última vez que o método SaveChanges foi chamado.


![](./Diagrama_States.png)


### Comandos do Entity Framework Core

**Add-Migration:** Adds a new migration.

**Drop-Database:** Drops the database.

**Remove-Migration:** Removes the last migration.

**Scaffold-DbContext:** Scaffolds a DbContext and entity types for a database.

**Script-Migration:** Generates a SQL script from migrations.

**Update-Database:** Updates the database to a specified migration.
