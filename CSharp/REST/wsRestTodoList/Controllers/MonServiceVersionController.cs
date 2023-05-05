using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace wsRestTodoList.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MonServiceController: ControllerBase
    {
        [HttpGet]
        public string Get() { return "MonService GET en version 1.0"; }

        [HttpGet, MapToApiVersion("2.0")]
        public string Get2() { return "MonService GET en version 2.0"; }

        [HttpPut]
        public string Put() { return "MonService PUT en version 1.0 & 2.0"; }
    }
}
