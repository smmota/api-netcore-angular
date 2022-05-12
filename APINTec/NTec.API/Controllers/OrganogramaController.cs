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
    [Route("organograma")]
    [ApiController]
    [Authorize]
    public class OrganogramaController : Controller
    {
        private readonly IColaboradorApplicationService _colaboradorApplicationService;

        public OrganogramaController(IColaboradorApplicationService colaboradorApplicationService)
        {
            _colaboradorApplicationService = colaboradorApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var result = _colaboradorApplicationService.ObterOrganograma();

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("O organograma não foi encontrado.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
