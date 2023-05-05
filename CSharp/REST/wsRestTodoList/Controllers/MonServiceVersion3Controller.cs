using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace wsRestTodoList.Controllers
{
    [ApiVersion("3.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/MonService")]
    public class MonServiceVersion3Controller : ControllerBase
    {

        [HttpGet]
        public string Get() { return "MonService GET en version 3.0"; }
    }
}
