using Ninject;
using Ninject.Modules;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using Rebus.Transport.Msmq;

namespace Domain.Infrastructure
{
    public class RebusModule : NinjectModule
    {
        const string InputQueueName = "my-app.input";
        public override void Load()
        {
            Kernel.Bind<IContainerAdapter>().To<Rebus.Ninject.NinjectContainerAdapter>().
                WithConstructorArgument("kernel", Kernel);
            //Kernel.Bind<IHandleMessages<TestEvent>>().To<TestHandler1>();
            //Kernel.Bind<IHandleMessages<TestEvent>>().To<TestHandler2>();

            var adapter = Kernel.Get<IContainerAdapter>();
            
            var bus = Configure.With(adapter)
                .Transport(t => t.UseMsmq(InputQueueName))
                //.Routing(r => r.TypeBased().Map<TestEvent>(inputQueueName))
                .Start();
            
        }
    }
}
