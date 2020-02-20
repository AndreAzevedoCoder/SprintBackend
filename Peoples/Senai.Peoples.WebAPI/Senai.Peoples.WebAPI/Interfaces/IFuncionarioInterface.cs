using Senai.Peoples.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();
        FuncionarioDomain BuscarPorId(int id);
    }
}
