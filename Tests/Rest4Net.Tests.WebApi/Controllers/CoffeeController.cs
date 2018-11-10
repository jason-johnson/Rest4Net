﻿using System.Collections.Generic;
using Rest4Net.Test.Common.Model;
using Rest4Net.Test.Common.Repository;
using Rest4NetCore;
using Rest4NetCore.Attributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
    }
}