using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebAPI.Domains;
using Senai.Peoples.WebAPI.Interfaces;
using Senai.Peoples.WebAPI.Repositories;

namespace Senai.Peoples.WebAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]


    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _funcionarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            return StatusCode(200, _funcionarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionario)
        {
            _funcionarioRepository.Cadastrar(funcionario);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult Demitir(int id)
        {
            _funcionarioRepository.Demitir(id);
            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {
            _funcionarioRepository.Atualizar(id,funcionarioAtualizado);
            return StatusCode(200);
        }




    }
}