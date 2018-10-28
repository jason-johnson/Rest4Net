using System.Collections.Generic;
using Rest4Net.Data;
using Rest4Net.Test.Common.Model;

namespace Rest4Net.Test.Common.Contract
{
    public class HomeContract : RestContract
    {
        public HomeContract(IEnumerable<Coffee> coffies, IEnumerable<Pastry> pastries)
        {
            Coffies = coffies;
            Pastries = pastries;
        }

        public IEnumerable<Coffee> Coffies { get; }
        public IEnumerable<Pastry> Pastries { get; }
    }
}
