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
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return StatusCode(200, _tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorID(int id)
        {
            return StatusCode(200, _tipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult CadastrarTipoUsuario(TblTiposUsuario tipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(tipoUsuario);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTipoUsuario(int id)
        {
            _tipoUsuarioRepository.Deletar(id);
            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarJogo(int id, TblTiposUsuario tipoUsuarioAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
            return StatusCode(200);
        }
    }
}