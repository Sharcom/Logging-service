using AL;
using DAL;
using FL;
using DTO;
using RabbitMQ_Messenger_Lib;
using RabbitMQ_Messenger_Lib.Types;

namespace Logging_service
{
    public class LogConsumer
    {
        private readonly ILogCollection logCollection;

        public LogConsumer(MessengerConfig messengerConfig, LogContext _logContext, ILogCollection? _logCollection = null)
        {
            Receiver receiver = new Receiver(messengerConfig, new List<Queue> { new Queue(name: "LOG", callbackMethod: LogMessage) });
            logCollection = _logCollection ?? ILogCollectionFactory.Get(_logContext);
        }

        private void LogMessage(object? sender, Message message)
        {
            LogDTO log = new LogDTO()
            {
                Origin = message.Origin,
                Message = message.Payload["message"].ToString(),
                Priority = Convert.ToInt32(message.Payload["priority"]),
                Timestamp = DateTime.Now,
                Handled = false,
            };
            logCollection.CreateLog(log);            
        }
    }
}
