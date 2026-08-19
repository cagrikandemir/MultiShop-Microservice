using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private static string message;
        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            var connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "localhost";

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            
            var consume = new EventingBasicConsumer(channel);

            consume.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
            };
            channel.BasicConsume(queue:"Kuyruk2",autoAck:false,consumer:consume);

            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost" 
            };
            var connection =  factory.CreateConnection();
            var channel =  connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", true, false, false, arguments: null);

            var messageContent = "Merhaba bugün hava çok soğuk.";

            var bytemessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: bytemessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

  
    }
}
