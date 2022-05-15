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
    [Route("cargo")]
    [ApiController]
    //[Authorize]
    public class CargoController : Controller
    {
        private readonly ICargoApplicationService _cargoApplicationService;

        public CargoController(ICargoApplicationService cargoApplicationService)
        {
            _cargoApplicationService = cargoApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var result = _cargoApplicationService.GetAll();

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Nenhum cargo foi encontrado!");
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

                var result = _cargoApplicationService.GetById(id);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("O cargo selecionado não foi encontrado!");
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
                var result = _cargoApplicationService.GetAllAtivos();

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Nenhum cargo foi encontrado!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CargoDto cargoDto)
        {
            try
            {
                if (cargoDto == null)
                    return NotFound();

                var result = _cargoApplicationService.Add(cargoDto);

                if (result)
                    return Ok("Cargo cadastrado com sucesso!");
                else
                    return BadRequest("Erro ao cadastrar o cargo!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] CargoDto cargoDto)
        {
            try
            {
                if (cargoDto == null)
                    return NotFound();

                var result = _cargoApplicationService.Update(cargoDto);

                if (result)
                    return Ok("Cargo atualizado com sucesso!");
                else
                    return BadRequest("Erro ao atualizar o cargo!");
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

                CargoDto cargoDto = _cargoApplicationService.GetById(id);

                if (cargoDto == null)
                    return NotFound();

                var result = _cargoApplicationService.Remove(id);

                if (result)
                    return Ok("Cargo removido com sucesso!");
                else
                    return BadRequest("Erro ao remover o cargo!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
