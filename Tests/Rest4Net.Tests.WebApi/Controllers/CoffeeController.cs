using System.Collections.Generic;
using System.Linq;
using Rest4Net.Tests.Common.Model;
using Rest4Net.Tests.Common.Repository;
using Rest4NetCore;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Controllers
{
    public class CoffeeController : RestController
    {
        private readonly IRepository<Coffee> repository;

        public CoffeeController(IRepository<Coffee> repository)
        {
            this.repository = repository;
        }

        [RestServiceMethod]
        public IEnumerable<Coffee> GetAll()
        {
            return repository.GetAll();
        }

        [RestServiceMethod]
        public Coffee GetInfo(string name)
        {
            return repository.GetAll(c => c.Name == name).Single();
        }
    }
}
