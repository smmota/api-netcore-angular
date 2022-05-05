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
    [Authorize]
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
            return Ok(_setorApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            return Ok(_setorApplicationService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] SetorDto setorDto)
        {
            try
            {
                if (setorDto == null)
                    return NotFound();

                _setorApplicationService.Add(setorDto);
                return Ok("Setor cadastrado com sucesso!");
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

                _setorApplicationService.Update(setorDto);
                return Ok("Setor atualizado com sucesso!");
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

                SetorDto setorDto = _setorApplicationService.GetById(id);

                if (setorDto == null)
                    return NotFound();

                _setorApplicationService.Remove(id);
                return Ok("Setor removido com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
