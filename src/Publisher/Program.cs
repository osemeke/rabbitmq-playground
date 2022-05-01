
using RabbitMQ.Client;
using System.Text;
using DomainCore;
using Newtonsoft.Json;
using Publisher;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

//CreateHostBuilder(args).Build().Run(); // TODO: move subscribe code to worker


var customerService = new CustomerService();
var customer = customerService.GetNewCustomer();
var message = JsonConvert.SerializeObject(customer);

//connectionString="amqp://demouser:demo123@localhost:5672/DemoApp"
const string IMMIGRATION_EXCHANGE = "ImmigrationExchange";
const string TICKET_QUEUE = "TicketAreaDisplay";
const string NURSE_QUEUE = "NurseAreaDisplay";

var factory = new ConnectionFactory();
//factory.Uri = new Uri(connectionString); //"amqp://itadmin:pass1234@localhost:5672/QMS";
factory.UserName = "itadmin";
factory.Password = "pass1234";
factory.HostName = "localhost";
factory.VirtualHost = "QMS";
factory.Port = 5672;
factory.AutomaticRecoveryEnabled = true;
//factory.DispatchConsumersAsync = true;
//var connection = factory.CreateConnection(); // connections

using (var connection = factory.CreateConnection("BookingServiceClient"))
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(IMMIGRATION_EXCHANGE, ExchangeType.Direct, true, false); // exchange

    channel.QueueDeclare(NURSE_QUEUE, false, false, false, null); // queue,durable,exclusive,autodel,
    channel.QueueDeclare(TICKET_QUEUE, false, false, false, null); // queue,durable,exclusive,autodel,

    channel.QueueBind(NURSE_QUEUE, IMMIGRATION_EXCHANGE, "nurse");
    channel.QueueBind(TICKET_QUEUE, IMMIGRATION_EXCHANGE, "ticket");

    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(IMMIGRATION_EXCHANGE, "ticket", null, body); // exchange,routingkey,properties,payload
}



// other methods

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddHostedService<BookingBackgroundWorker>();
        });



