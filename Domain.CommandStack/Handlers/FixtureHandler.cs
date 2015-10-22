using System.Threading.Tasks;
using Rebus.Handlers;

namespace Domain.CommandStack.Handlers
{
    public class FixtureHandler : IHandleMessages<CreateFixtureCommand>
    {
        public Task Handle(CreateFixtureCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}