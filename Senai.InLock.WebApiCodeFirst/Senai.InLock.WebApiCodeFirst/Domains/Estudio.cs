using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApiCodeFirst.Domains
{
    // Define o nome da tabela
    [Table("Estudio")]
    public class Estudio
    {
        //Chave Primaria
        [Key]
        //Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "Precisa de nome no estudio!")]
        [Column(TypeName = "VARCHAR (255)")]
        public string nomeEstudio { get; set; }

        public List<Jogos> Jogos { get; set; }
    }
}
