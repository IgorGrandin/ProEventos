using Perfil.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfil.Infrastructure.Interface
{
    public interface IEventosRepository
    {
        List<Eventos> ListarEventos();
        Eventos GetById(int id);
    }
}
