using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.Manha.Domains;
using Senai.InLock.Manha.Interfaces;
using Senai.InLock.Manha.Repositories;

namespace Senai.InLock.Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private IJogoRepository _IJogoRepository { get; set; }

        public JogosController()
        {
            _IJogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return StatusCode(200, _IJogoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorID(int id)
        {
            return StatusCode(200, _IJogoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult CadastrarJogo(TblJogos jogo)
        {
            _IJogoRepository.Cadastrar(jogo);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarJogo(int id)
        {
            _IJogoRepository.Deletar(id);
            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarJogo(int id, TblJogos jogoAtualizado)
        {
            _IJogoRepository.Atualizar(id, jogoAtualizado);
            return StatusCode(200);
        }
    }
}