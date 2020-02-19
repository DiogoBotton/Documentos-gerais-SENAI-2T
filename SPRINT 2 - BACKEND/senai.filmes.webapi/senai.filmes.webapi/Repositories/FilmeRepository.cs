using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository : IFilmesRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source - Nome do Servidor
        /// initial catalog - Nome do Banco de Dados
        /// integrated security=true - Faz a autenticação com o usuário do sistema
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        private string StringConexao = "Data Source=DEV1\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132;";

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
                string query = "select f.IdFilme, f.Titulo, f.IdGenero, g.Nome from Filmes as f join Generos as g on f.IdGenero = g.IdGenero;";

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
                        // Cria um objeto genero do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        // Adiciona o genero criado à tabela generos
                        filmes.Add(filme);
                    }
                }
            }

            // Retorna a lista de generos
            return filmes;
        }

        public List<FilmeDomain> GetByTitulo(string filtro)
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = $"select f.IdFilme, f.Titulo, f.IdGenero, g.Nome from Filmes as f join Generos as g on f.IdGenero = g.IdGenero where f.Titulo like '%{filtro}%';" ;

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
                        // Cria um objeto genero do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        // Adiciona o genero criado à tabela generos
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }
        public FilmeDomain GetById(int idFilme)
        {
            FilmeDomain filmeDomain = null;
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Propriedade direto na string (interpolação), risco de SQL INJECTION
                string query = $"select f.IdFilme, f.Titulo, f.IdGenero, g.Nome from Filmes as f join Generos as g on f.IdGenero = g.IdGenero where IdFilme = {idFilme};";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        filmeDomain = new FilmeDomain()
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                    }
                }
            }
            return filmeDomain;
        }

        public FilmeDomain Insert(FilmeDomain filmeDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"insert into Filmes (Titulo, IdGenero) values ('{filmeDomain.Titulo}','{filmeDomain.IdGenero}');";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return filmeDomain;
        }
        public FilmeDomain Update(int idFilme, FilmeDomain filmeDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"update Filmes set Titulo = '{filmeDomain.Titulo}',IdGenero = '{filmeDomain.IdGenero}' where IdFilme = '{idFilme}'";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            filmeDomain.IdFilme = idFilme;
            return filmeDomain;
        }
        public void Delete(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"delete from Filmes where IdFIlme = {idFilme}";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
