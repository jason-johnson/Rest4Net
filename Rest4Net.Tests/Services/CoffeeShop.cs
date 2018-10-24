using System.Collections.Generic;
using System.Linq;
using Rest4Net.Attributes;
using Rest4Net.Test.Model;
using Rest4Net.Test.Repository;

namespace Rest4Net.Test.Services
{
    public class CoffeeShop : RestService
    {
        private readonly TestRepository<Coffee> coffeeRepository;

        public CoffeeShop()
        {
            coffeeRepository = new TestRepository<Coffee>(new List<Coffee>());
        }

        [RestServiceMethod]
        public Coffee OrderCoffee(string name)
        {
            var coffies = coffeeRepository.GetAll(c => c.Name == name);

            return coffies.FirstOrDefault();
        }
    }
}
