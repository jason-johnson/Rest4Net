﻿using Rest4NetCore.Data;

namespace Rest4Net.Test.Common.Contracts
{
    public class CoffeeContract : RestContract
    {
        public CoffeeContract(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
