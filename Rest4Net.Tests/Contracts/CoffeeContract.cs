using Rest4Net.Data;

namespace Rest4Net.Test.Contracts
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
