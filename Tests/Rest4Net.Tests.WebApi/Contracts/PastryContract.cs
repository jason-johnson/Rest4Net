using Rest4Net.Test.Common.Model;
using Rest4NetCore;
using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(Pastry))]
    public class PastryContract : RestContractBase<Pastry>
    {
    }
}
