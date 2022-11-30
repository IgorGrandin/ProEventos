using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Perfil.Core.Models;
using Perfil.Infrastructure.Entities;

namespace Perfil.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventosModel, Eventos>();
            CreateMap<Eventos, EventosModel>();
        }
    }
}
