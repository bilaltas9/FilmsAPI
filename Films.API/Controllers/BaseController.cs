using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Films.API.Controllers
{
    [Route("api/[controller]s")]
    [Produces("application/json")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
    }
}
