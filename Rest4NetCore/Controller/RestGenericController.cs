using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest4NetCore.Attributes;

namespace Rest4NetCore.Controller
{
    public class RestGenericController : ControllerBase
    {
        private Dictionary<Type, Type> contractMap = new Dictionary<Type, Type>();
        private Dictionary<Type, Dictionary<string, Type>> modelMap = new Dictionary<Type, Dictionary<string, Type>>();

        internal void AddContractMapping(RestContractAttribute contractInfo, Type contract)
        {
            if (!modelMap.ContainsKey(contractInfo.ModelClass))
            {
                modelMap.Add(contractInfo.ModelClass, new Dictionary<string, Type>());
            }

            modelMap[contractInfo.ModelClass][contractInfo.Version] = contract;
            contractMap[contract] = contractInfo.ModelClass;
        }

        internal void AddEntryPoint(Type type, MethodInfo method)
        {

        }

        internal string AddServiceMethod(Type type, MethodInfo method)
        {
            throw new NotImplementedException();
        }

        internal async Task<IActionResult> HandleRequest(HttpContext context)
        {
            return Ok();
        }
    }
}
