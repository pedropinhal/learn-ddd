using System.Collections.Generic;
using System.Linq;

namespace Domain.Persistence
{
    public class Database
    {
        private readonly List<Fixture> _database = new List<Fixture>();
        private static Database _instance;

        private Database()
        {
            _database.Add(new Fixture());
        }
        public static Database Instance
        {
            get
            {
                if (_instance == null) { _instance = new Database(); }
                return _instance;
                    
            }
        }

        public IQueryable<Fixture> ReadOnlyFixtures { get { return _database.AsQueryable(); } }

        public List<Fixture> Fixtures { get { return _database;} }
    }
}
