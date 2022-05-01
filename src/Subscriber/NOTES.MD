
using RabbitMQ.Client;
using System.Text;
using DomainCore;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

const string TICKET_QUEUE = "TicketAreaDisplay";
const string IMMIGRATION_EXCHANGE = "ImmigrationExchange";

var factory = new ConnectionFactory();
factory.UserName = "itadmin";
factory.Password = "pass1234";
factory.HostName = "localhost";
factory.VirtualHost = "QMS";
factory.Port = 5672;
factory.AutomaticRecoveryEnabled = true;
//factory.DispatchConsumersAsync = true;

var connection = factory.CreateConnection("BookingServiceClient");

var channel = connection.CreateModel();

channel.BasicQos(0, 1, false);
    //channel.ExchangeDeclare(IMMIGRATION_EXCHANGE, ExchangeType.Direct, true, false); // exchange
    channel.QueueDeclare(TICKET_QUEUE, false, false, false, null); // queue,durable,exclusive,autodel,

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += MessageReceived;

    //consumer.Received += (sender, ea) =>
    //{
    //    var body = ea.Body.ToArray();
    //    var message = Encoding.UTF8.GetString(body);
    //    Console.WriteLine($"received -> "+message); // OR Call notify
    //    channel.BasicAck(ea.DeliveryTag, false);
    //};

    //channel.BasicConsume(TICKET_QUEUE, true, consumer);


channel.BasicConsume(queue: "hello",
                        autoAck: true,
                        consumer: consumer);

//

void MessageReceived(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"received -> " + message); // OR Call notify
    channel.BasicAck(e.DeliveryTag, false);
}

Console.ReadKey();

/*
    var consumer = new AsyncEventingBasicConsumer(channel);
    consumer.Received += async Task (sender, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        Console.WriteLine($"received -> "+message); // OR Call notify

        channel.BasicAck(ea.DeliveryTag, false);


        await Task.CompletedTask;
    };*/

