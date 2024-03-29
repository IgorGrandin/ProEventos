﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfil.Infrastructure.Entities
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public Eventos Evento { get; set; }
        public int? PalestranteID { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}
