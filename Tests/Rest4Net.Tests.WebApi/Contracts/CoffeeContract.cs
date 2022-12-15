﻿using Rest4Net.Tests.Common.Model;
using Rest4NetCore;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(Coffee))]
    public class CoffeeContract : RestContractBase<Coffee>
    {
    }
}
