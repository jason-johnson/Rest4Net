using System.Collections.Generic;
using Rest4Net.Test.Common.Model;

namespace Rest4Net.Tests.WebApi.Model
{
    // NOTE: Only needed to support versioning
    public class Home
    {
        public string Greeting { get; set; }
        public IEnumerable<string> Coffees { get; set; }
        public IEnumerable<Pastry> Pastries { get; set; }
    }
}
