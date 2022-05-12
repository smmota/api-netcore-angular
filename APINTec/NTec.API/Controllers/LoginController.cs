using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTec.API.Services;
using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTec.API.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public LoginController(IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        [Route("auth")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticate([FromBody] LoginDto loginDto)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDto.LoginUser) || string.IsNullOrEmpty(loginDto.Senha))
                    return NotFound((new { message = "Informe o usuário e senha!" }));

                UsuarioDto usuarioDto = new UsuarioDto()
                {
                    LoginUser = loginDto.LoginUser,
                    Senha = loginDto.Senha
                };

                var usuario = _usuarioApplicationService.GetUsuarioByUserAndPassword(usuarioDto.LoginUser, usuarioDto.Senha);

                if (usuario == null)
                    return NotFound((new { message = "Usuário ou senha inválidos"}));

                var token = TokenService.GenerateToken(usuario);
                usuario.Senha = "";

                return new
                {
                    token = token
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
