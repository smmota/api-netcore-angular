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
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticate([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = await _usuarioApplicationService.GetUsuarioByUserAndPassword(usuarioDto.LoginUser, usuarioDto.Senha);


                if (usuario == null)
                    return NotFound((new { message = "Usuário ou senha inválidos "}));

                var token = TokenService.GenerateToken(usuario);
                usuario.Senha = "";

                return new
                {
                    usuario = usuario,
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
