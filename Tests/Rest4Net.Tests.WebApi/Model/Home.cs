using System.Collections.Generic;

namespace Rest4Net.Tests.WebApi.Model
{
    public class Home
    {
        public IEnumerable<string> Coffees { get; set; }
        public IEnumerable<string> Pastries { get; set; }
    }
}
