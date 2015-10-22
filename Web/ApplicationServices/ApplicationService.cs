using System.Linq;
using Domain.CommandStack;
using Domain.Infrastructure;
using Domain.ReadStack;
using Web.Models;

namespace Web.ApplicationServices
{
    public class ApplicationService : IApplicationService
    {
        private readonly IBus _bus;

        public ApplicationService(IBus bus)
        {
            _bus = bus;
        }

        public IndexViewModel GetFixtures()
        {
            var data = new Data().ReadOnlyFixtures.ToList();
            return new IndexViewModel(data);
        }

        public void CreateFixture()
        {
            var command = new CreateFixtureCommand();
            _bus.Send(command);
            /*var commandData = new CommandData();
            commandData.Fixtures.Add(new Fixture());
            */
        }
    }
}