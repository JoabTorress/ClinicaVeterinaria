using Clinica.Interfaces;
using Clinica.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Clinica.Repositories
{
    public class DonoRepository : IDonoRepository
    {

        //Criando uma conexão com o Banco de Dados
        readonly string connectionString = "data source=DESKTOP-DFD11KQ\\SQLEXPRESS;Integrated Security=true;Initial Catalog=ClinicaVeterinaria";
        public bool Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {

                conexao.Open();

                //Aqui é uma inserção no banco de dados
                string script = "DELETE FROM Dono WHERE Id=@id";

                // criei um comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    // fazemos as declarações das varias por parametros
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if(linhasAfetadas == 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public ICollection<Dono> GetAll()
        {
            var _donos = new List<Dono>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Dono";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    //Lendo todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Enquanto tiver leitura ele irá executar
                        while (reader.Read())
                        {
                            _donos.Add(new Dono
                            {
                                Id = (int)reader["ID"],
                                Nome = (string)reader[1],
                                Categoria = (string)reader[2],
                                Celular = (string)reader[3]
                            });
                        }
                    }
                }
                return _donos;
            }
        }

            public Dono GetById(int id)
            {
            var _donos = new Dono();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Dono WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                    //Lendo todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Enquanto tiver leitura ele irá executar
                        while (reader.Read())
                        {

                            _donos.Id = (int)reader["ID"];
                            _donos.Nome = (string)reader[1];
                            _donos.Categoria = (string)reader[2];
                            _donos.Celular = (string)reader[3];
                            
                        }
                    }
                }
                return _donos;
            }
        }

            public Dono Insert(Dono dono)
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {

                    conexao.Open();

                    //Aqui é uma inserção no banco de dados
                    string script = "INSERT INTO Dono (Categoria, Nome, Celular) VALUES (@Categoria, @Nome,@Celular)";

                    // criei um comando de execução no banco
                    using (SqlCommand cmd = new SqlCommand(script, conexao))
                    {
                        // fazemos as declarações das varias por parametros
                        cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = dono.Nome;
                        cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = dono.Categoria;
                        cmd.Parameters.Add("@Celular", SqlDbType.NVarChar).Value = dono.Celular;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                }
                return dono;
            }

            public Dono Update(int id, Dono dono)
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {

                    conexao.Open();

                    //Aqui é uma inserção no banco de dados
                    string script = "UPDATE DONO SET NOME=@Nome, Categoria=@categoria, Celular=@celular WHERE Id=@id";

                    // criei um comando de execução no banco
                    using (SqlCommand cmd = new SqlCommand(script, conexao))
                    {
                        // fazemos as declarações das varias por parametros
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                        cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = dono.Nome;
                        cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = dono.Categoria;
                        cmd.Parameters.Add("@Celular", SqlDbType.NVarChar).Value = dono.Celular;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        dono.Id = id;
                    }

                }
                return dono;
            }
        }

       
    }


