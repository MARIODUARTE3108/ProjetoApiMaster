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
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AuthController(IUsuarioRepository usuarioRepository)
        {
        _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(AuthModel usuario)
        {

            try
            {
                var usuarioExistente = _usuarioRepository.ObterPorEmail(usuario.Email);
                if (usuarioExistente != null)
                {

                    return Ok(
                        new
                        {
                            Mensagem = "Usuário autenticado com sucesso",

                        }
                        );
                }
                else
                {
                    return StatusCode(401, "Acesso negado, usuário inválido.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}