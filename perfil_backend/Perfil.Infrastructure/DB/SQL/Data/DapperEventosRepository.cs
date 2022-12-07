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
    public class DapperEventosRepository : SQLServerRepository, IPerfilRepository
    {
        private string querySQL = string.Empty;

        public DapperEventosRepository(IOptions<Settings> settings) : base(settings)
        {
        }

        #region ' GERAL - Add() '
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' GERAL - Update() '
        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' GERAL - Delete() '
        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' GERAL - DeleteRange() '
        public void DeleteRange<T>(T[] entity) where T : class
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' GERAL - SaveChangesAsync() '
        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' EVENTOS - ListarEventos '
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

        #region ' EVENTOS - GetById() '
        public Eventos GetById(int id)
        {
            try
            {
                string query = $"SELECT * FROM {TabelasModel.Tabela_Eventos} WHERE Id = @Id";
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

        #region ' EVENTOS - GetAllEventosAsync() '
        public Task<Eventos[]> GetAllEventosAsync(bool includePalestrantes)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' EVENTOS - GetAllEventosByTemaAsync() '
        public Task<Eventos[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' EVENTOS - GetAllEventosByIdAsync() '
        public Task<Eventos[]> GetAllEventoByIdAsync(int id, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' PALESTRANTES - GetAllPalestrantesAsync '
        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' PALESTRANTES - GetAllPalestrantesByNomeAsync() '
        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ' PALESTRANTES - GetAllPalestrantesByIdAsync() '
        public Task<Palestrante[]> GetAllPalestranteByIdAsync(int id, bool includeEventos)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
