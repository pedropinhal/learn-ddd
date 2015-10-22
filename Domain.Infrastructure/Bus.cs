namespace Domain.Infrastructure
{
    public class Bus : IBus
    {
        private readonly Rebus.Bus.IBus _bus;

        public Bus(Rebus.Bus.IBus bus)
        {
            _bus = bus;
        }

        public void Send<T>(T message) where T : IMessage
        {
            _bus.Send(message);
        }
    }
}
