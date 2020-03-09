using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApiCodeFirst.Domains
{
    [Table("Estudios")]
    public class Usuarios
    {
        //Chave Primaria
        [Key]
        //Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }


        [Required(ErrorMessage = "Precisa de email!")]
        [Column(TypeName = "VARCHAR (255)")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "Precisa de senha!")]
        [Column(TypeName = "VARCHAR (255)")]
        [DataType(DataType.Password)]
        public string senha { get; set; }


        public int idTipoUsuarios { get; set; }
        [ForeignKey("idTipoUsuario")]
        public int idTipoUsuario { get; set; }
    }
}
