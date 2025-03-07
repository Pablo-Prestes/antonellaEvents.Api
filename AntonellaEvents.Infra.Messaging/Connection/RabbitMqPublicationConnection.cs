using RabbitMQ.Client;


namespace AntonellaEvents.Infra.Messaging.Connection
{
	public class RabbitMqPublicationConnection
	{
		private readonly IConnection _connection;
		private readonly IModel _channel;

		public RabbitMqPublicationConnection()
		{
			var factory = new ConnectionFactory
			{
				HostName = "localhost", // Endereço do seu RabbitMQ
				Port = 5672,            // Porta padrão do RabbitMQ
				UserName = "guest",
				Password = "guest",
				AutomaticRecoveryEnabled = true,               
				RequestedHeartbeat = TimeSpan.FromSeconds(60)    // Configura o heartbeat
			};
				
			// Cria a conexão com o RabbitMQ
			_connection = factory.CreateConnection();

			// Cria um canal (IModel) para publicar mensagens
			_channel = _connection.CreateModel();

			// Declara a fila de publicação (caso ainda não exista)
			_channel.QueueDeclare(
				queue: "fila_publicacao",
				durable: true,    // A fila persiste mesmo após reinício do broker
				exclusive: false, // Pode ser acessada por outras conexões
				autoDelete: false, // Não será excluída automaticamente quando não estiver em uso
				arguments: null);
		}

		// Propriedade para acessar o canal e publicar mensagens
		public IModel Channel => _channel;

		// Dispose para fechar a conexão e o canal corretamente
		public void Dispose()
		{
			_channel?.Close();
			_connection?.Close();
		}
	}
}
