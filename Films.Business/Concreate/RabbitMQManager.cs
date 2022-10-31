using Films.Business.Abstract;
using RabbitMQ.Client;
using System.Text;

namespace Films.Business.Concreate
{
    public class RabbitMQManager : IRabbitMqService
    {
        public RabbitMQManager()
        {

        }
        public void DeclareQue()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare("FilmQueue");
        }

        public void SendMessageToQueue(string queMessage)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(queMessage);
            channel.BasicPublish(exchange: "", routingKey: "FilmQueue", body: body);
        }
    }
}
