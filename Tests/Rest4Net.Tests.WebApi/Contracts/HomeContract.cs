using Rest4Net.Tests.WebApi.Controllers;
using Rest4Net.Tests.WebApi.Model;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(Home))]
    [RestReference("PlaceOrder", typeof(HomeController), "PlaceOrder")]
    public class HomeContract
    {
        public HomeContract()
        {
        }
    }
}
