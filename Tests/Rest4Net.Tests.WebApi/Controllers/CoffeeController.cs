using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Rest4Net.Attributes;
using Rest4Net.Test.Common.Model;
using Rest4Net.Test.Common.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rest4Net.Tests.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CoffeeController : RestController
    {
        private readonly IRepository<Coffee> repository;

        public CoffeeController(IRepository<Coffee> repository)
        {
            this.repository = repository;
        }

        [RestServiceMethod]
        public IEnumerable<Coffee> GetAllCoffee()
        {
            return repository.GetAll();
        }
    }
}
