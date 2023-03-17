using ApiUsuarios.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperarSenhaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(RecuperarSenhaPostModel model)
        {
            return Ok();
        }

    }
}
