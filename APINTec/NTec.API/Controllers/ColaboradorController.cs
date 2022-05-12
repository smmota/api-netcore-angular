using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using NTec.Domain.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTec.API.Controllers
{
    [Route("colaborador")]
    [ApiController]
    [Authorize]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorApplicationService _colaboradorApplicationService;
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorApplicationService colaboradorApplicationService, IColaboradorRepository colaboradorRepository)
        {
            _colaboradorApplicationService = colaboradorApplicationService;
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var result = _colaboradorApplicationService.GetAll();

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Nenhum cargo foi encontrato!");
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

                var result = _colaboradorApplicationService.GetById(id);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("O cargo selecionado não foi encontrado.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ColaboradorDto colaboradorDto)
        {
            try
            {
                if (colaboradorDto == null)
                    return NotFound();

                var result = _colaboradorApplicationService.Add(colaboradorDto);

                if (result)
                    return Ok("Colaborador cadastrado com sucesso!");
                else
                    return BadRequest("Erro ao cadastrar o colaborador!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ColaboradorDto colaboradorDto)
        {
            try
            {
                if (colaboradorDto == null)
                    return NotFound();

                var result = _colaboradorApplicationService.Update(colaboradorDto);

                if (result)
                    return Ok("Colaborador atualizado com sucesso!");
                else
                    return BadRequest("Erro ao atualizar o colaborador!");
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

                ColaboradorDto colaboradorDto = _colaboradorApplicationService.GetById(id);

                if (colaboradorDto == null)
                    return NotFound();

                if (_colaboradorApplicationService.VerificaSePossuiSubordinados(colaboradorDto.Id))
                    return UnprocessableEntity("Não foi possível remover o registro selecionado. O colaborador possui subordinados alocados na estrutura.");

                var result = _colaboradorApplicationService.Remove(id);

                if (result)
                    return Ok("Colaborador removido com sucesso!");
                else
                    return BadRequest("Erro ao remover o colaborador!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
