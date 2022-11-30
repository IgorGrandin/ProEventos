using Perfil.Core.Interfaces;
using Perfil.Core.Models;
using Perfil.Infrastructure.Entities;
using Perfil.Infrastructure.Interface;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Perfil.Infrastructure.Models;

namespace Perfil.Core.Services
{
    public class EventosService : IEventosService
    {
        private readonly IEventosRepository _eventosRepository;
        private readonly IMapper _mapeador;
        private readonly IOptions<Settings> _settings;

        public EventosService(
            IEventosRepository eventosRepository,
            IMapper mapeador,
            IOptions<Settings> settings)
        {
            _eventosRepository = eventosRepository;
            _mapeador = mapeador;
            _settings = settings;
        }

        #region ' Listar Todos os Eventos '
        public List<EventosModel> ListarEventos()
        {
            List<Eventos> listaEventos = _eventosRepository.ListarEventos();

            List<EventosModel> listaModel = _mapeador.Map<List<Eventos>, List<EventosModel>>(listaEventos);

            return listaModel;
        }
        #endregion

        #region ' Listar Todos os Eventos '
        public Eventos GetById(int id)
        {
            return _eventosRepository.GetById(id);
        }
        #endregion
    }
}
