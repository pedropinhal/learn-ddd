using System.Linq;
using Domain.Persistence;

namespace Domain.ReadStack
{
    public class Data
    {
        public IQueryable<Fixture> ReadOnlyFixtures { get { return Database.Instance.ReadOnlyFixtures; } }
    }
}
