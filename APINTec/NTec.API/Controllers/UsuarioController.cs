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
            try
            {
                var result = _usuarioApplicationService.GetAll();

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Nenhum usuário foi encontrato!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                var result = _usuarioApplicationService.GetById(id);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("O usuário selecionado não foi encontrado!");
            }
            catch (Exception)
            {
                throw;
            }
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

                var result = _usuarioApplicationService.Add(usuarioDto);

                if (result)
                    return Ok("Usuário cadastrado com sucesso!");
                else
                    return BadRequest("Erro ao cadastrar o usuário!");
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

                var result = _usuarioApplicationService.Update(usuarioDto);

                if (result)
                    return Ok("Usuário atualizado com sucesso!");
                else
                    return BadRequest("Erro ao atualizar o usuário!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                UsuarioDto usuarioDto = _usuarioApplicationService.GetById(id);

                if (usuarioDto == null)
                    return NotFound();

                var result = _usuarioApplicationService.Remove(id);

                if (result)
                    return Ok("Usuário removido com sucesso!");
                else
                    return BadRequest("Erro ao remover o usuário!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
