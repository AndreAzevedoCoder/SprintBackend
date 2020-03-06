using System;
using System.Collections.Generic;

namespace Senai.InLock.Manha.Domains
{
    public partial class TblUsuarios
    {
        public int IdUsuario { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TblTiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
