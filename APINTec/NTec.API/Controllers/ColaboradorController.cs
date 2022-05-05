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
    [Route("colaborador")]
    [ApiController]
    [Authorize]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorApplicationService _colaboradorApplicationService;

        public ColaboradorController(IColaboradorApplicationService colaboradorApplicationService)
        {
            _colaboradorApplicationService = colaboradorApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_colaboradorApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            return Ok(_colaboradorApplicationService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ColaboradorDto colaboradorDto)
        {
            try
            {
                if (colaboradorDto == null)
                    return NotFound();

                _colaboradorApplicationService.Add(colaboradorDto);
                return Ok("Colaborador cadastrado com sucesso!");
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

                _colaboradorApplicationService.Update(colaboradorDto);
                return Ok("Colaborador atualizado com sucesso!");
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

                _colaboradorApplicationService.Remove(id);
                return Ok("Colaborador removido com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
