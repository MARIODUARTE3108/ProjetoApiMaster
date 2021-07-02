using ApiDomain.Entities;
using ApiRepository.Contracts;
using ApiRepository.Repository;
using ApiTarefas.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiTarefas.Controller
{
        [Route("api/[controller]")]
        [ApiController]
        public class AccountController : ControllerBase
        {
        private readonly IUsuarioRepository _usuarioRepository;
        public AccountController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]
            public IActionResult Post(AccountModel model)
            {
            try
            {
                var usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Senha = model.Senha;

                var verificaEmail = _usuarioRepository.ObterPorEmail(model.Email);
              
                if (verificaEmail != null)
                {
                    return UnprocessableEntity("O email informado já encontra-se cadastrado. Tente outro.");
                }

                _usuarioRepository.Inserir(usuario);

                return Ok(usuario);                
            }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
}
