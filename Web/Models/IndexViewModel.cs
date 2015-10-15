using System.Collections.Generic;
using Domain;

namespace Web.Models
{
    public class IndexViewModel
    {
        public List<string> Fixtures { get; set; }
        public IndexViewModel(List<Fixture> data)
        {
            Fixtures = new List<string>();
            data.ForEach(d => Fixtures.Add("fixture"));
        }
    }
}