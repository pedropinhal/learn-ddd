using System;
using System.Threading.Tasks;
using System.Timers;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using Rebus.Transport.Msmq;

namespace BusDemo
{
    public class Class1
    {
        public static void Main()
        {
            const string inputQueueName = "my-app.input";
            using (var activator = new BuiltinHandlerActivator())
            using (var timer = new Timer())
            {
                activator.Register(() => new PrintDateTime());

                var bus = Configure.With(activator)
                    .Transport(t => t.UseMsmq(inputQueueName))
                    .Routing(r => r.TypeBased().Map<DateTime>(inputQueueName))
                    .Start();

                timer.Elapsed += delegate { bus.Send(DateTime.Now).Wait(); };
                timer.Interval = 1000;
                timer.Start();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }

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
