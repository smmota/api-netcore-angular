using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTec.API.Controllers
{
    [Route("setor")]
    [ApiController]
    //[Authorize]
    public class SetorController : Controller
    {
        private readonly ISetorApplicationService _setorApplicationService;

        public SetorController(ISetorApplicationService setorApplicationService)
        {
            _setorApplicationService = setorApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var result = _setorApplicationService.GetAll();

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Nenhum setor foi encontrado!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("ativos")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAtivos()
        {
            try
            {
                var result = _setorApplicationService.GetAllAtivos();

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Nenhum setor foi encontrado!");
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

                var result = _setorApplicationService.GetById(id);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Setor não encontrado!");
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter o setor selecionado.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] SetorDto setorDto)
        {
            try
            {
                if (setorDto == null)
                    return NotFound();

                var result = _setorApplicationService.Add(setorDto);

                if (result)
                    return Ok("Setor cadastrado com sucesso!");
                else
                    return BadRequest("Erro ao cadastrar o setor!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] SetorDto setorDto)
        {
            try
            {
                if (setorDto == null)
                    return NotFound();

                var result = _setorApplicationService.Update(setorDto);

                if (result)
                    return Ok("Setor atualizado com sucesso!");
                else
                    return BadRequest("Erro ao atualizar o setor!");
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

                SetorDto setorDto = _setorApplicationService.GetById(id);

                if (setorDto == null)
                    return NotFound();

                var result = _setorApplicationService.Remove(id);

                if (result)
                    return Ok("Setor removido com sucesso!");
                else
                    return BadRequest("Erro ao remover o setor!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
