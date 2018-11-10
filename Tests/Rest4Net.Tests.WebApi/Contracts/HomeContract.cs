using Rest4Net.Tests.WebApi.Model;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(Home))]
    public class HomeContract
    {
        public HomeContract()
        {
        }
    }
}
