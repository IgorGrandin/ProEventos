using Perfil.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfil.Infrastructure.Interface
{
    public interface IPerfilRepository
    {

        //GERAL
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangesAsync();

        //EVENTOS
        List<Eventos> ListarEventos();
        Eventos GetById(int id);
        //Eventos GetByTema(string tema);
        //Eventos Create(Eventos evento);
        //void Update(Eventos evento);
        //void Delete(int id);
        Task<Eventos[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Eventos[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Eventos[]> GetAllEventoByIdAsync(int id, bool includePalestrantes);

        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteByIdAsync(int id, bool includeEventos);

    }
}
