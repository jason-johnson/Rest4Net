using Rest4Net.Tests.WebApi.Model;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(Home), Version = "1.2")]
    public class HomeContract : OldHomeContract
    {
        public string Greeting
        {
            get => Model.Greeting;
            set => Model.Greeting = value;
        }
    }
}
