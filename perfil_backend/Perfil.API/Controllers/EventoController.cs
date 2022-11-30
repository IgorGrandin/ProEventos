using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Perfil.Core.Models;
using Perfil.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        private readonly ILogger<EventoController> _logger;
        private readonly IEventosService _eventosService;

        public EventoController(ILogger<EventoController> logger, IEventosService eventosService)
        {
            _logger = logger;
            _eventosService = eventosService;
        }

        #region ' Listar Todos os Eventos '
        /// <summary>
        /// Método responsável por listar todos os Eventos cadastrados
        /// </summary>
        [HttpGet]
        //[Authorize(AuthenticationSchemes = "TokenAuthenticationScheme")]
        public IActionResult ListarEventos()
        {
            List<EventosModel> listaEventos = _eventosService.ListarEventos();

            return Ok(listaEventos);
        }
        #endregion

        #region ' Listar Eventos por Id '
        /// <summary>
        /// Método responsável por filtras os eventos por Id
        /// </summary>
        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = "TokenAuthenticationScheme")]
        public IActionResult GetById(int id)
        {
            try
            {
                var evento = _eventosService.GetById(id);
                return Ok(evento);
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message);
            }
        }
        #endregion

    }
}
