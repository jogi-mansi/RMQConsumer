using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
Console.WriteLine("This is Inventory Consumer");
var factory = new ConnectionFactory()
{
    HostName = "localhost",
};
var connection = factory.CreateConnection();
var channel = connection.CreateModel();
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (m, arge) =>
{
    var body = arge.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);

};
channel.BasicConsume(queue: "AmzInventoryQueue", autoAck: true, consumer: consumer);
//channel.BasicConsume(queue: "ProductOrder", autoAck: true, consumer: consumer);

Console.WriteLine("consuming started");
Console.ReadLine();