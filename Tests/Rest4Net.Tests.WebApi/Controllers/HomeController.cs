using System.Linq;
using Rest4Net.Tests.Common.Model;
using Rest4Net.Tests.Common.Repository;
using Rest4Net.Tests.WebApi.Contracts;
using Rest4Net.Tests.WebApi.Model;
using Rest4NetCore;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Controllers
{
    public class HomeController : RestController
    {
        private readonly IRepository<Coffee> coffeeRepository;
        private readonly IRepository<Pastry> pastryRepository;

        public HomeController(IRepository<Coffee> coffeeRepository, IRepository<Pastry> pastryRepository)
        {
            this.coffeeRepository = coffeeRepository;
            this.pastryRepository = pastryRepository;
        }

        [RestEntrypoint]
        public Home GetInitialResource()
        {
            var result = new Home
            {
                Greeting = "Hello and welcome to the coffee shop!",
                Coffees = coffeeRepository.GetAll(c => c.Count > 0).Select(c => c.Name),
                Pastries = pastryRepository.GetAll(p => p.Count > 0)
            };

            return result;
        }

        [RestServiceMethod]
        public OrderResultContract PlaceOrder(OrderContract order)      // TODO: If the return type and/or parameter are already contracts nothing more is needed
        {
            var result = new OrderResultContract
            {
                Order = new OrderContract()
            };

            foreach (var entry in order.Coffees)
            {
                var coffee = coffeeRepository.GetAll(c => c.Name == entry.Key).Single();

                if (coffee.Count < 1) continue;

                var quantity = entry.Value > coffee.Count ? coffee.Count : entry.Value;

                coffee.Count -= quantity;

                coffeeRepository.Update(coffee);

                result.Order.Coffees.Add(entry.Key, quantity);

                result.Price += coffee.Price * quantity;
            }

            foreach (var entry in order.Pastries)
            {
                var pastry = pastryRepository.GetAll(c => c.Name == entry.Key).Single();

                if (pastry.Count < 1) continue;

                var quantity = entry.Value > pastry.Count ? pastry.Count : entry.Value;

                pastry.Count -= quantity;

                pastryRepository.Update(pastry);

                result.Order.Pastries.Add(entry.Key, quantity);

                result.Price += pastry.Price * quantity;
            }

            return result;
        }
    }
}
