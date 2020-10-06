using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculaTroco.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculaTroco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaTrocoController : ControllerBase
    {
        private CalculaTrocoService _service;

        [HttpPost("calcular")]
        public IActionResult CalculaTroco([FromBody] Valores valores)
        {
            try
            {
                // Chama o serviço responsável por calcular a composição do troco
                _service = new CalculaTrocoService();
                return Ok(_service.CalculaTroco(valores.VlrCompra, valores.VlrPago));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }   

        }

    }
}
