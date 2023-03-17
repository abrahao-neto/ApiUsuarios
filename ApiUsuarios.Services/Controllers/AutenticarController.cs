using ApiUsuarios.Services.Configurations.Jwt;
using ApiUsuarios.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        //atributo
        private readonly JwtTokenCreator? _jwtTokenCreator;

        //construtor com entrada de argumentos (injeção de dependência)
        public AutenticarController(JwtTokenCreator? jwtTokenCreator)
        {
            _jwtTokenCreator = jwtTokenCreator;
        }

        [HttpPost]
        public IActionResult Post(AutenticarPostModel model)
        {
            var email = "admin@cotiinformatica.com.br";
            var senha = "@Admin123";

            if (email.Equals(model.Email) && senha.Equals(model.Senha))
            {
                return Ok(new
                {
                    mensagem = "Usuário autenticado com sucesso",
                    usuario = email,
                    token = _jwtTokenCreator.GenerateToken(model.Email)
                });
            }

            return Unauthorized(new { erro = "Acesso negado." });
        }
    }
}



