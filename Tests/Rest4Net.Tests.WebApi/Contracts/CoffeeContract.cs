using Rest4Net.Test.Common.Model;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(Coffee))]
    public class CoffeeContract
    {
        public CoffeeContract()
        {
        }
    }
}
