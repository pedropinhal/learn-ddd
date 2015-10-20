using System;
using System.Threading.Tasks;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using Rebus.Transport.Msmq;

namespace Domain.Infrastructure
{
    public class Bus : IBus
    {
        const string InputQueueName = "my-app.input";
        private readonly Rebus.Bus.IBus _bus;

        public Bus()
        {
            using (var activator = new BuiltinHandlerActivator())
            {
                activator.Register(() => new PrintDateTime());

                _bus = Configure.With(activator)
                   .Transport(t => t.UseMsmq(InputQueueName))
                    .Routing(r => r.TypeBased().Map<DateTime>(InputQueueName))
                   .Start();
            }
        }
        public void Send<T>(T message) where T : IMessage
        {
            _bus.Send(DateTime.Now).Wait();
        }
    }

    public class PrintDateTime : IHandleMessages<DateTime>
    {
        public async Task Handle(DateTime message)
        {
            Console.WriteLine("The time is {0}", message);
        }

    }
}
