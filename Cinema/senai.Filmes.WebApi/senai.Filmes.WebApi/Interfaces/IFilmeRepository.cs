using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes</returns>
        List<FilmeDomain> Listar();
        List<FilmeDomain>  BuscarPorNome(string Titulo);
        FilmeDomain RetornarPorID(int RetornarPorID);
        void Adicionar(FilmeDomain novoFilme);
        void Delete(int id);
        void Put(int id, FilmeDomain filmeAtualizado);  
    }
}
