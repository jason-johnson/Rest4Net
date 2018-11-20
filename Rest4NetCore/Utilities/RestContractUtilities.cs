using System.Collections.Generic;
using System.Linq;

namespace Rest4NetCore.Utilities
{
    public static class RestContractUtilities
    {
        public static IEnumerable<TContract> ToContracts<TContract, TModel>(IEnumerable<TModel> entries) where TContract : IRestContract<TModel>, new()
        {
            return entries.Select(e => { var c = new TContract(); c.FromModel(e); return c; });
        }

        public static IEnumerable<TModel> FromContracts<TContract, TModel>(IEnumerable<TContract> entries) where TContract : IRestContract<TModel>
        {
            return entries.Select(c => c.GetModel());
        }
    }
}
