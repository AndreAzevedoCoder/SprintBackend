using System;
using System.Collections.Generic;

namespace Senai.InLock.Manha.Domains
{
    public partial class TblEstudios
    {
        public TblEstudios()
        {
            TblJogos = new HashSet<TblJogos>();
        }

        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }

        public ICollection<TblJogos> TblJogos { get; set; }
    }
}
