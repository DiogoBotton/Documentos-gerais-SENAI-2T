using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    public interface IFilmesRepository
    {
        IEnumerable<FilmeDomain> Listar();
        FilmeDomain Insert(FilmeDomain filmeDomain);
        FilmeDomain Update(int idGenero, FilmeDomain filmeDomain);
        void Delete(int idGenero);
        FilmeDomain GetById(int idGenero);
        IEnumerable<FilmeDomain> GetByTitulo(string filtro);
    }
}
