using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApiCodeFirst.Domains
{
    [Table("Jogos")]
    public class Jogos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJogo { get; set; }

        [Column(TypeName ="VARCHAR (255)")]
        [Required(ErrorMessage ="Precisa")]
        public string nomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Precisa")]
        public string descricao { get; set; }

        [Column(TypeName = "DATE")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Precisa")]
        public DateTime dataLancamento { get; set; }


        [Column(TypeName = "DECIMAL (18,2)")]
        [Required(ErrorMessage = "Precisa")]
        [DataType(DataType.Currency)]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "Precisa")]
        public int idEstudio { get; set; }
        [ForeignKey("idEstudio")]
        public Estudio Estudio { get; set; }
    }
}
