using Senai.Peoples.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Interfaces
{
    interface IFuncionarioRepository
    {

        //GET
        List<FuncionarioDomain> Listar();
        FuncionarioDomain BuscarPorId(int id);
        FuncionarioDomain BuscarPorNome(string nome);
        List<FuncionarioDomain> NomesCompletos();
        List<FuncionarioDomain> OrdenarAsc();

        //POST
        void Cadastrar(FuncionarioDomain novoFuncionario);

        //DELETE
        void Demitir(int id);
        
        //PUT
        void Atualizar(int id , FuncionarioDomain funcionarioAtualizado);

    }
}
