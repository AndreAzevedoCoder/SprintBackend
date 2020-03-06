using Senai.InLock.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.Manha.Interfaces
{
    interface IJogoRepository
    {
        //GET
        List<TblJogos> Listar();
        TblJogos BuscarPorId(int id);
        //TblJogos BuscarPorNome(string nome);
        //List<TblJogos> NomesCompletos();
        //List<TblJogos> OrdenarAsc();

        //POST
        void Cadastrar(TblJogos novoJogo);

        //DELETE
        void Deletar(int id);

        //PUT
        void Atualizar(int id, TblJogos jogoAtualizado);
    }
}
