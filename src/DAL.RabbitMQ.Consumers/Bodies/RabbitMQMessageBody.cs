using System;

namespace DAL.RabbitMQ.Consumers.Bodies
{
    [Serializable]
    public abstract class RabbitMQMessageBody
    {
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
