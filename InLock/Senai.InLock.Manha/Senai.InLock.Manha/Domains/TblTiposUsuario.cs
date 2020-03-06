using System;
using System.Collections.Generic;

namespace Senai.InLock.Manha.Domains
{
    public partial class TblTiposUsuario
    {
        public TblTiposUsuario()
        {
            TblUsuarios = new HashSet<TblUsuarios>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomeTipo { get; set; }

        public ICollection<TblUsuarios> TblUsuarios { get; set; }
    }
}
