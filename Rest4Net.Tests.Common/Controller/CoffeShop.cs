using System.Linq;
using Rest4Net.Attributes;
using Rest4Net.Test.Common.Model;
using Rest4Net.Test.Common.Repository;

namespace Rest4Net.Tests.Common.Controller
{
    public class CoffeeShop : RestController
    {
        private readonly IRepository<Coffee> coffeeRepository;

        public CoffeeShop(IRepository<Coffee> repository)
        {
            coffeeRepository = repository;
        }

        [RestServiceMethod]
        public Coffee OrderCoffee(string name)
        {
            var coffies = coffeeRepository.GetAll(c => c.Name == name);

            return coffies.FirstOrDefault();
        }
    }
}
