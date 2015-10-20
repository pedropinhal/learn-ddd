using System.Linq;
using Domain.CommandStack;
using Domain.ReadStack;
using Web.Models;

namespace Web.ApplicationServices
{
    public class ApplicationService
    {
        public IndexViewModel GetFixtures()
        {
            var data = new Data().ReadOnlyFixtures.ToList();
            return new IndexViewModel(data);
        }

        public void CreateFixture()
        {
            var command = new CreateFixtureCommand();
            MvcApplication.Bus.Send(command);
            /*var commandData = new CommandData();
            commandData.Fixtures.Add(new Fixture());
            */
        }
    }
}