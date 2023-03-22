using ApiUsuarios.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriarContaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CriarContaPostModel model)
        {
            return Ok();
        }
    }
}





