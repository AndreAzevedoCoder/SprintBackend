using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos gêneros
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source - Nome do Servidor
        /// initial catalog - Nome do Banco de Dados
        /// integrated security=true - Faz a autenticação com o usuário do sistema
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        private string StringConexao = "Data Source=DEV6\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132;";

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        public List<FilmeDomain> Listar()
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "EXEC MostarTodosOsFilmes";

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
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        // Adiciona o genero criado à tabela generos
                        filmes.Add(filme);
                    }
                }
            }

            // Retorna a lista de generos
            return filmes;
        }

        public List<FilmeDomain> BuscarPorNome(string titulo)
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "EXEC MostarTodosOsFilmesPorNome @Titulo";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        FilmeDomain filme = new FilmeDomain();
                        filme.IdFilme = Convert.ToInt32(rdr["IdFilme"]);
                        filme.IdGenero = Convert.ToInt32(rdr["IdGenero"]);
                        filme.Titulo = rdr["Titulo"].ToString();
                        // Adiciona o genero criado à tabela generos
                        filmes.Add(filme);
                    }
                }
            }

            // Retorna a lista de generos
            return filmes;
        }

        public FilmeDomain RetornarPorID(int id)
        {
            FilmeDomain retorno = new FilmeDomain();
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "SELECT * FROM Filmes WHERE IdFilme = @id";

                // Abre a conexão com o banco de dados
                con.Open();

                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);
                    rdr = cmd.ExecuteReader();
                    //cmd.ExecuteNonQuery();
                    if (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        retorno.IdFilme = Convert.ToInt32(rdr["IdFilme"]);
                        retorno.IdGenero = Convert.ToInt32(rdr["IdGenero"]);
                        retorno.Titulo = rdr["Titulo"].ToString();
                        return retorno;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Adicionar(FilmeDomain novoFilme)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "INSERT INTO Filmes(Titulo,IdGenero) VALUES(@Titulo, @Id)";

                // Abre a conexão com o banco de dados

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);
                    cmd.Parameters.AddWithValue("@Id", novoFilme.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            if (RetornarPorID(id) != null)
            {
                // Declara a SqlConnection passando a string de conexão
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    // Declara a instrução a ser executada
                    string query = "DELETE FROM Filmes WHERE IdFilme=@id;";

                    // Abre a conexão com o banco de dados
                    con.Open();



                    // Declara o SqlCommand passando o comando a ser executado e a conexão
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();

                    }
                }
            }
        }

        public void Put(int id, FilmeDomain filmeAtualizado)
        {
            GeneroDomain generoAtualizado = filmeAtualizado.Genero;
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "";
                if(generoAtualizado != null)
                {
                    query += "UPDATE Filmes SET IdGenero = @Genero WHERE IdFilme = @id;";
                }
                if (filmeAtualizado.Titulo != null)
                {
                    query += "UPDATE Filmes SET Titulo = @Filme WHERE IdFilme = @id;";
                }

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Filme", filmeAtualizado.Titulo);
                    if(generoAtualizado != null)
                    {
                        cmd.Parameters.AddWithValue("@Genero", generoAtualizado.IdGenero);
                    }
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }


    }
}
