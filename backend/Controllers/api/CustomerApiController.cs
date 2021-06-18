using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    public class CustomerApiController : Controller
    {
        [HttpGet]
        public StatusCodeResult Search()
        {
            return Ok();
        }
    }
}