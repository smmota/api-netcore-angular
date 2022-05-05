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
    [Authorize]
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
            return Ok(_cargoApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Ok(_cargoApplicationService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CargoDto cargoDto)
        {
            try
            {
                if (cargoDto == null)
                    return NotFound();

                _cargoApplicationService.Add(cargoDto);
                return Ok("Cargo cadastrado com sucesso!");
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

                _cargoApplicationService.Update(cargoDto);
                return Ok("Cargo atualizado com sucesso!");
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

                _cargoApplicationService.Remove(id);
                return Ok("Cargo removido com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
