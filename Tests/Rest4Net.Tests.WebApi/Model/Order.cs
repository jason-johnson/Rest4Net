using System.Collections.Generic;

namespace Rest4Net.Tests.WebApi.Model
{
    public class Order
    {
        public Dictionary<string, int> Coffees { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> Pastries { get; set; } = new Dictionary<string, int>();
    }
}
