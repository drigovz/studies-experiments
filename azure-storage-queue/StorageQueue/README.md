# Azure Storage Queue Toolkit

Exemplo de biblioteca para auxiliar na conexão com o Azure Storage Queue.

No projeto nós temos:
* No diretório **Client** onde estamos configurando e criando a conexão com a instância do Azure Storage Queue.
* No diretório **Interfaces** as interfaces utilizadas para injeção de dependência nos projetos que forem consumir nossa library
* No diretório **Service** a implementação de todos os métodos contendo a lógica de conexão e gerenciamento de mensagens no Azure Storage Queue.
* E por fim no diretório **Utils** temos a classe **Message** que irá nos auxiliar com a serialização e deserialização de mensagens para as filas.

### Consumindo a biblioteca
Para consumirmos a biblioteca, devemos primeiramente realizar a injeção de dependência da interface **IAzureQueueService** para o serviço **AzureQueueService**, feito isso, devemos criar a conexão com o Azure Storage Queue, que pode ser feito por meio do seguinte código:

````csharp
var client = Connection.Connect(connectionString, queueName);
````
Onde devemos passar a **string de conexão** e o **nome da fila** que desejamos criar. A string de conexão com o Azure storage Queue utilizando em Localhost é a seguinte:

``string connectionString = "AccountName=your-account-name-here;" +
                    "AccountKey=your-account-key-here;" +
                    "DefaultEndpointsProtocol=http;" +
                    "QueueEndpoint=http://127.0.0.1:10001/your-account-name-here";``

Com isso, conseguimos criar uma instância para o nosso serviço e a partir dai utilizar os serviços disponíveis em nossa classe **AzureQueueService**.

```csharp
await service.CreateAsync();

await service.DequeueAllMessagesAsync();
```

