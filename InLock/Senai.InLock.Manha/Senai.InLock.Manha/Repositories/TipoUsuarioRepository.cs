using Senai.InLock.Manha.Domains;
using Senai.InLock.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.Manha.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        //GET
        public List<TblTiposUsuario> Listar()
        {
            List<TblTiposUsuario> listaDeTiposUsuario = ctx.TblTiposUsuario.ToList();
            return listaDeTiposUsuario;
        }
        public TblTiposUsuario BuscarPorId(int id)
        {
            TblTiposUsuario tiposUsuario = ctx.TblTiposUsuario.FirstOrDefault(p => p.IdTipoUsuario == id);
            return tiposUsuario;
        }

        //POST
        public void Cadastrar(TblTiposUsuario novoTipoUsuario)
        {
            ctx.TblTiposUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        //DELETE
        public void Deletar(int id)
        {
            ctx.TblTiposUsuario.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        //PUT
        public void Atualizar(int id, TblTiposUsuario tipoUsuarioAtualizado)
        {
            TblTiposUsuario usuarioAtualizado = BuscarPorId(id);
            if(String.IsNullOrEmpty(tipoUsuarioAtualizado.NomeTipo) == false)
            {
                usuarioAtualizado.NomeTipo = tipoUsuarioAtualizado.NomeTipo;
            }
            ctx.SaveChanges();
        }
    }
}
