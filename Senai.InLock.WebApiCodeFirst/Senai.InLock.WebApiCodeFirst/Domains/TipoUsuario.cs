using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApiCodeFirst.Domains
{
    // Define o nome da tabela
    [Table("tiposUsuario")]
    public class TipoUsuario
    {
        //Chave Primaria
        [Key]
        //Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "Precisa de titulo!")]
        [Column(TypeName = "VARCHAR (255)")]
        public string titulo { get; set; }
    }
}
