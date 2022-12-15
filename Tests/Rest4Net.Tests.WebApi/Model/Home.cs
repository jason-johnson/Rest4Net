using Rest4Net.Tests.Common.Model;

namespace Rest4Net.Tests.WebApi.Model
{
    // NOTE: Only needed to support versioning
    public class Home
    {
        public Home(string greeting, IEnumerable<string> coffees, IEnumerable<Pastry> pastries)
        {
            Greeting = greeting;
            Coffees = coffees;
            Pastries = pastries;
        }

        public string Greeting { get; set; }
        public IEnumerable<string> Coffees { get; set; }
        public IEnumerable<Pastry> Pastries { get; set; }
    }
}
