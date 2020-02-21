using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Domains
{
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string dataDeNascimento { get; set; }
    }
}
