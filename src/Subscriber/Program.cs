using DomainCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

class Program
{

    const string TICKET_QUEUE = "TicketAreaDisplay";
    const string IMMIGRATION_EXCHANGE = "ImmigrationExchange";

    public static void Main()
    {
        //var factory = new ConnectionFactory() { HostName = "localhost", UserName = "ossy", Password = "pass1234" };
        var factory = new ConnectionFactory();
        factory.UserName = "itadmin";
        factory.Password = "pass1234";
        factory.HostName = "localhost";
        factory.VirtualHost = "QMS";
        factory.Port = 5672;

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: TICKET_QUEUE,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);

                var customer = JsonConvert.DeserializeObject<Customer>(message);
                Console.WriteLine(" [x] Customer Name {0}", customer?.Name);
            };
            channel.BasicConsume(queue: TICKET_QUEUE,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}