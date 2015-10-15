using System.Collections.Generic;
using Domain.Persistence;

namespace Domain.CommandStack
{
    public class CommandData
    {
       

        public List<Fixture> Fixtures
        {
            get { return Database.Instance.Fixtures; }
        }
    }
}