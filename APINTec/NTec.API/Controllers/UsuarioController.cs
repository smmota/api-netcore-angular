using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTec.API.Services;
using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTec.API.Controllers
{
    [Route("usuario")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public UsuarioController(IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_usuarioApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            return Ok(_usuarioApplicationService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                //CriptoService criptoService = new CriptoService();
                //usuarioDto.HashPwd = criptoService.CreateHash(usuarioDto.Senha);

                _usuarioApplicationService.Add(usuarioDto);
                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                _usuarioApplicationService.Update(usuarioDto);
                return Ok("Usuário atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                UsuarioDto usuarioDto = _usuarioApplicationService.GetById(id);

                if (usuarioDto == null)
                    return NotFound();

                _usuarioApplicationService.Remove(id);
                return Ok("Usuário removido com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
