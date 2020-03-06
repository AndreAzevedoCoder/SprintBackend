using System;
using System.Collections.Generic;

namespace Senai.InLock.Manha.Domains
{
    public partial class TblJogos
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public double Valor { get; set; }
        public int? IdEstudio { get; set; }

        public TblEstudios IdEstudioNavigation { get; set; }
    }
}
