using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rest4NetCore.Controller
{
    public class RestGenericController : ControllerBase
    {
        public async Task<IActionResult> HandleRequest()
        {
            return Ok();
        }
    }
}
