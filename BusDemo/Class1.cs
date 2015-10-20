using System;
using System.Threading.Tasks;
using System.Timers;
using Ninject;
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
            /*
            const string inputQueueName = "my-app.input";
            using (var activator = new BuiltinHandlerActivator())
            using (var timer = new Timer())
            {
                activator.Register(() => new PrintDateTime());
               
                var bus = Configure.With(activator)
                    .Transport(t => t.UseMsmq(inputQueueName))
                    .Routing(r => r.TypeBased().Map<DateTime>(inputQueueName))
                    .Start();

                timer.Elapsed += delegate
                {
                    bus.Send("hello").Wait();
                    bus.Send(DateTime.Now).Wait(); 
                    
                };
                timer.Interval = 1000;
                timer.Start();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
                */
            IKernel kernel = new StandardKernel();
            
            kernel.Bind<IContainerAdapter>().To<Rebus.Ninject.NinjectContainerAdapter>().
                WithConstructorArgument("kernel", kernel);
            kernel.Bind<IHandleMessages<TestEvent>>().To<TestHandler>();

            var _adapter = kernel.Get<IContainerAdapter>();

            var bus = Configure.With(_adapter)
                .Transport(t => t.UseMsmq("inputQueueName"))
                .Routing(r => r.TypeBased().Map<TestEvent>("inputQueueName"))
                .Start();

            bus.Send(new TestEvent()).Wait();
            Console.ReadLine();
        }

    }

        
    

    public class PrintDateTime : IHandleMessages<DateTime>
    {
        public async Task Handle(DateTime message)
        {
            Console.WriteLine("The time is {0}", message);
        }
    
    }

    public class TestHandler : IHandleMessages<TestEvent>
    {
      

        public async Task Handle(TestEvent message)
        {
            Console.WriteLine("The message is {0}", message);
        }
    }

    public class TestEvent
    {
    }
}
