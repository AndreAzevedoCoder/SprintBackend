using Senai.InLock.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.Manha.Interfaces
{
    interface ITipoUsuarioRepository
    {
        //GET
        List<TblTiposUsuario> Listar();
        TblTiposUsuario BuscarPorId(int id);

        //POST
        void Cadastrar(TblTiposUsuario novoJogo);

        //DELETE
        void Deletar(int id);

        //PUT
        void Atualizar(int id, TblTiposUsuario jogoAtualizado);
    }
}
