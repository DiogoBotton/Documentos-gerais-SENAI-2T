using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionario
    {
        private string StringConexao = "Data Source=DEV1\\SQLEXPRESS; initial catalog=PeoplesDB; user Id=sa; pwd=sa@132;";

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"delete from Funcionarios where Id = {id}";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Funcionario GetById(int id)
        {
            Funcionario funcionario = null;
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Propriedade direto na string (interpolação), risco de SQL INJECTION
                string query = $"select Id, Nome, Sobrenome from Funcionarios where Id = {id}";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        funcionario = new Funcionario()
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                    }
                }
            }
            return funcionario;
        }

        public IEnumerable<Funcionario> GetByNome(string filtro)
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<Funcionario> funcionarios = new List<Funcionario>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = $"select Id, Nome, Sobrenome from Funcionarios where Nome like '%{filtro}%' OR Sobrenome like '%{filtro}%';";

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
                        Funcionario funcionario = new Funcionario
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            Id = Convert.ToInt32(rdr["Id"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Adiciona o genero criado à tabela generos
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public Funcionario Insert(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"insert into Funcionarios (Nome,Sobrenome) values ('{funcionario.Nome}','{funcionario.Sobrenome}');";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return funcionario;
        }

        public IEnumerable<Funcionario> Listar()
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<Funcionario> funcionarios = new List<Funcionario>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "SELECT Id, Nome, Sobrenome from Funcionarios";

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
                        // Cria um objeto genero do tipo Funcionario
                        Funcionario funcionario = new Funcionario
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            Id = Convert.ToInt32(rdr["Id"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Adiciona o genero criado à tabela generos
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public Funcionario Update(int id, Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"update Funcionarios set Nome = '{funcionario.Nome}', Sobrenome = '{funcionario.Sobrenome}' where Id = '{id}'";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            funcionario.Id = id;
            return funcionario;
        }
    }
}
