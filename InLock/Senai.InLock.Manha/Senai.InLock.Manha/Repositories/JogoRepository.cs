using Senai.InLock.Manha.Domains;
using Senai.InLock.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.Manha.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        //GET
        public List<TblJogos> Listar()
        {
            List<TblJogos> ListaDeJogos = ctx.TblJogos.ToList();
            return ListaDeJogos;
        }
        public TblJogos BuscarPorId(int id)
        {
           TblJogos Jogos = ctx.TblJogos.FirstOrDefault(p => p.IdJogo == id);
            return Jogos;
        }

        //POST
        public void Cadastrar(TblJogos novoJogo)
        {
            ctx.TblJogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        //DELETE
        public void Deletar(int id)
        {
            ctx.TblJogos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        //PUT
        public void Atualizar(int id, TblJogos jogoAtualizado)
        {
            TblJogos jogo = BuscarPorId(id);
            if(String.IsNullOrEmpty(jogoAtualizado.NomeJogo) == false)
            {
                jogo.NomeJogo = jogoAtualizado.NomeJogo;
            }
            if (String.IsNullOrEmpty(jogoAtualizado.Descricao) == false)
            {
                jogo.Descricao = jogoAtualizado.Descricao;
            }
            if (jogoAtualizado.DataLancamento != null)
            {
                jogo.DataLancamento = jogoAtualizado.DataLancamento;
            }
            if (jogoAtualizado.Valor != null)
            {
                jogo.Valor = jogoAtualizado.Valor;
            }
            if (jogoAtualizado.IdEstudio != null)
            {
                jogo.IdEstudio = jogoAtualizado.IdEstudio;
            }

            ctx.SaveChanges();
        }
    }
}
