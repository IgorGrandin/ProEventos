using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Perfil.Core.Models;
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

        public EventoController(ILogger<EventoController> logger)
        {
            _logger = logger;
        }

        public IEnumerable<EventosModel> _evento = new EventosModel[]
        {
            new EventosModel(){
                EventoId = 1,
                Tema = "Angular e ASP.NET",
                Local = "São Paulo",
                Lote = "1° Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.png"
                },
            new EventosModel(){
                EventoId = 2,
                Tema = "Teclado",
                Local = "São Paulo",
                Lote = "2° Lote",
                QtdPessoas = 500,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImagemURL = "fotoTeclado.png"
                }
        };

        [HttpGet]
        public IEnumerable<EventosModel> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<EventosModel> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id );
        }

        [HttpPost("UpdateEvento")]
        public IActionResult Post([FromBody] string str)
        {
            return Ok();
        }
    }
}
