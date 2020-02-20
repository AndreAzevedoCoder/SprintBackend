using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}