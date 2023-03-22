using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Models;
using ApiUsuarios.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        //atributo
        private readonly IUsuarioDomainService? _usuarioDomainService;

        //construtor para injeção de dependência
        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public void CriarConta(CriarContaPostModel model)
        {
            throw new NotImplementedException();
        }
    }
}



