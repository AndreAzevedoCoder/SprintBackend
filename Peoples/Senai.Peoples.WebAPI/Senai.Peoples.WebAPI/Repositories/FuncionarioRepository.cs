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
                        funcionario.dataDeNascimento = rdr["dataDeNascimento"].ToString();

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
                        funcionario.dataDeNascimento = rdr["dataDeNascimento"].ToString();

                    }
                }

                return funcionario;
            }
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "EXEC AdicionarFuncionario @Nome , @Sobrenome, @dataDeNascimento";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.sobrenome);
                    cmd.Parameters.AddWithValue("@dataDeNascimento", novoFuncionario.dataDeNascimento);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Demitir(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "EXEC DemitirFuncionario @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string query = "";

                if(funcionarioAtualizado.nome != null)
                {
                    query += "UPDATE Funcionarios SET Nome = @nome WHERE idFuncionario = @id;";
                }

                if (funcionarioAtualizado.sobrenome != null)
                {
                    query += "UPDATE Funcionarios SET Sobrenome = @sobrenome WHERE idFuncionario = @id;";
                }

                if (funcionarioAtualizado.dataDeNascimento != null)
                {
                    query += "UPDATE Funcionarios SET DataDeNascimento = @dataDeNascimento WHERE idFuncionario = @id;";
                }

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    if (funcionarioAtualizado.nome != null)
                    {
                        cmd.Parameters.AddWithValue("@nome", funcionarioAtualizado.nome);
                    }

                    if (funcionarioAtualizado.sobrenome != null)
                    {
                        cmd.Parameters.AddWithValue("@sobrenome", funcionarioAtualizado.sobrenome);
                    }

                    if (funcionarioAtualizado.sobrenome != null)
                    {
                        cmd.Parameters.AddWithValue("@dataDeNascimento", funcionarioAtualizado.dataDeNascimento);
                    }

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public FuncionarioDomain BuscarPorNome (string nome)
        {
            FuncionarioDomain funcionario = new FuncionarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "EXEC MostrarFuncionarioPorNome @Nome";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {

                        funcionario.idFuncionario = Convert.ToInt32(rdr["idFuncionario"]);
                        funcionario.nome = rdr["Nome"].ToString();
                        funcionario.sobrenome = rdr["Sobrenome"].ToString();
                        funcionario.dataDeNascimento = rdr["dataDeNascimento"].ToString();

                    }
                }

                return funcionario;
            }
        }



        public List<FuncionarioDomain> NomesCompletos()
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
                        funcionario.nome = rdr["Nome"].ToString() +" "+ rdr["Sobrenome"].ToString();
                        funcionario.dataDeNascimento = rdr["dataDeNascimento"].ToString();

                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de generos
            return funcionarios;
        }


        public List<FuncionarioDomain> OrdenarAsc()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "EXEC OrdernarNomesASC";

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
                        funcionario.dataDeNascimento = rdr["dataDeNascimento"].ToString();

                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de generos
            return funcionarios;
        }


    }
}
