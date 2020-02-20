using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos generos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _filmeRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            // Faz a chamada para o método .Listar();
            FilmeDomain novoGenero = _filmeRepository.RetornarPorID(id);
            if (novoGenero == null)
            {
                return StatusCode(404);
            }
            else
            {
                return StatusCode(200, novoGenero);
            }
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Adicionar(novoFilme);
            return StatusCode(200);
        }

        [HttpDelete("{ParamOne}")]
        public IActionResult Delete(int ParamOne)
        {
            //int id = HttpContext.Current.Request.Url.AbsolutePath;
            _filmeRepository.Delete(ParamOne);
            return StatusCode(200);
        }

        [HttpGet("Buscar/{Titulo}")]
        public IActionResult Buscar(string Titulo)
        {
            // Faz a chamada para o método .Listar();

            return StatusCode(200, _filmeRepository.BuscarPorNome(Titulo));

        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, FilmeDomain filmeAtualizado)
        {
            //int id = HttpContext.Current.Request.Url.AbsolutePath;
            _filmeRepository.Put(id, filmeAtualizado);
            return StatusCode(200);
        }

    }
}