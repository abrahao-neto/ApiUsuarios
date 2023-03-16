using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarDadosController : ControllerBase
    {
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
    }
}
