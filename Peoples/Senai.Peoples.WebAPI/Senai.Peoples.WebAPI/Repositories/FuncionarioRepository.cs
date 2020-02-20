using Senai.Peoples.WebAPI.Domains;
using Senai.Peoples.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string StringConexao = "Data Source=DEV6\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "EXEC MostarTodosOsFuncionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain();

                        funcionario.idFuncionario = Convert.ToInt32(rdr["idFuncionario"]);
                        funcionario.nome = rdr["Nome"].ToString();
                        funcionario.sobrenome = rdr["Sobrenome"].ToString();

                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de generos
            return funcionarios;
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            FuncionarioDomain funcionario = new FuncionarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "EXEC MostrarFuncionarioPorId @id";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        funcionario.idFuncionario = Convert.ToInt32(rdr["idFuncionario"]);
                        funcionario.nome = rdr["Nome"].ToString();
                        funcionario.sobrenome = rdr["Sobrenome"].ToString();
                    }
                }

                return funcionario;
            }
        }
    }
}
