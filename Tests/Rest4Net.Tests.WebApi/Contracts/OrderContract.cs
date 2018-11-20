using System.Collections.Generic;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(OrderContract))]
    public class OrderContract
    {
        public Dictionary<string, int> Coffees { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> Pastries { get; set; } = new Dictionary<string, int>();
    }
}
