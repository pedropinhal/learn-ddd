namespace Domain.Infrastructure
{
    public interface IBus
    {
        void Send<T>(T message) where T : IMessage;
    }
}