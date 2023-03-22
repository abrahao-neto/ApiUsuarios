using ApiUsuarios.Domain.Helpers;
using ApiUsuarios.Domain.Interfaces.Repositories;
using ApiUsuarios.Domain.Interfaces.Services;
using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Services
{
    /// <summary>
    /// Classe de serviços de domínio para Usuario
    /// </summary>
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributo
        private readonly IUsuarioRepository? _usuarioRepository;

        //construtor para inicialização dos atributos (injeção de dependência)
        public UsuarioDomainService(IUsuarioRepository? usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CriarUsuario(Usuario usuario)
        {
            #region Não permitir o cadastro de usuários com o mesmo email

            if (_usuarioRepository.Get(u => u.Email.Equals(usuario.Email)) != null)
                throw new ArgumentException("O email informado já está cadastrado no sistema. Tente outro.");

            #endregion

            #region Criptografar a senha do usuário

            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            #endregion

            _usuarioRepository.Add(usuario);
        }
    }
}



