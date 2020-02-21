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
        void Cadastrar(FuncionarioDomain novoFuncionario);
        void Demitir(int id);
        void Atualizar(int id , FuncionarioDomain funcionarioAtualizado);
    }
}
