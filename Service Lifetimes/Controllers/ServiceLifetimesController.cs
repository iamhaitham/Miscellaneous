using Microsoft.AspNetCore.Mvc;

namespace Service_Lifetimes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceLifetimesController : ControllerBase
    {
        public ServiceLifetimesController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
