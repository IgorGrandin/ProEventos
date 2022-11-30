using Perfil.Core.Models;
using Perfil.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfil.Core.Interfaces
{
    public interface IEventosService
    {
        List<EventosModel> ListarEventos();
        Eventos GetById(int id);
    }
}
