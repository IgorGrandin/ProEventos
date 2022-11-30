using _Frameworkni.Infrastructure.Models;
using Dapper;
using Microsoft.Extensions.Options;
using Perfil.Infrastructure.Entities;
using Perfil.Infrastructure.Interface;
using Perfil.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfil.Infrastructure.DB.SQL.Data
{
    public class DapperEventosRepository : SQLServerRepository, IEventosRepository
    {
        private string querySQL = string.Empty;

        public DapperEventosRepository(IOptions<Settings> settings) : base(settings)
        {
        }

        #region ' ListarEventos '
        public List<Eventos> ListarEventos() 
        {
            List<Eventos> listaEventos;

            try
            {
                querySQL = $"SELECT * FROM {TabelasModel.Tabela_Eventos}";

                listaEventos = Database.Query<Eventos>(querySQL).ToList();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return listaEventos;
        }
        #endregion

        #region 'Metodo Get Evento By Id'
        public Eventos GetById(int id)
        {
            try
            {
                string query = $"SELECT * FROM {TabelasModel.Tabela_Eventos} WHERE EventoId = @Id";
                return GetEvent(query, id.ToString());
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        private Eventos GetEvent(string query, string id)
        {
            var parameters = new { Id = id };
            Eventos evento;

            evento = Database.QuerySingleOrDefault<Eventos>(query, parameters);

            return evento;
        }
        #endregion

    }
}
