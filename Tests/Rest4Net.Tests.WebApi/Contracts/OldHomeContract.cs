using Rest4Net.Tests.Common.Model;
using Rest4Net.Tests.WebApi.Controllers;
using Rest4Net.Tests.WebApi.Model;
using Rest4NetCore;
using Rest4NetCore.Attributes;
using Rest4NetCore.Utilities;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(Home), Version = "1.1")]
    [RestReference("place_order", typeof(HomeController), "PlaceOrder")]
    public class OldHomeContract : RestContractBase<Home>
    {
        [RestReference("CoffeeInfo", typeof(CoffeeController), "GetInfo")]
        public IEnumerable<string> Coffees
        {
            get => Model.Coffees;
            set => Model.Coffees = value;
        }

        public IEnumerable<PastryContract> Pastries
        {
            get => RestContractUtilities.ToContracts<PastryContract, Pastry>(Model.Pastries);
            set => Model.Pastries = RestContractUtilities.FromContracts<PastryContract, Pastry>(value);
        }
    }
}
