using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using cadastro_senai.Dominio;

namespace cadastro_senai.Repositorio
{
    public class AlunoRep
    {
        string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=CodeXP;Integrated Security=True";   
        
   
        /// <summary>
        /// Lista todos os alunos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista do tipo aluno</returns>
        public List<Aluno> Listar()   
        {   
            List<Aluno> lstaluno = new List<Aluno>();   
   
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))   
                {                       
                    //instrução sql para listar os alunos
                    string sqlQuery = "";   
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);   
    
                    con.Open();   
                    SqlDataReader rdr = cmd.ExecuteReader();   
    
                    while (rdr.Read())   
                    {   
                        Aluno aluno = new Aluno();   
    
                        aluno.Id = Convert.ToInt32(rdr["Id"]);   
                        aluno.Nome = rdr["Nome"].ToString();   
                        aluno.Email = rdr["Email"].ToString();   
                        aluno.Sexo = rdr["Sexo"].ToString();  
                        aluno.Idade = Convert.ToInt32(rdr["Idade"]);   
    
                        lstaluno.Add(aluno);   
                    }   
                    con.Close();   
                }   
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstaluno;   
        }   
   
        /// <summary>
        /// Cadastra um aluno
        /// </summary>
        /// <param name="aluno">Parametro de entrada do tipo aluno</param>    
        public void Cadastrar(Aluno aluno)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para cadastrar o aluno
                string sqlQuery = "";   
                SqlCommand cmd = new SqlCommand(sqlQuery, con); 

                con.Open();   
                cmd.ExecuteNonQuery();   
                con.Close();   
            }   
        }   
   
        /// <summary>
        /// Atualiza um aluno
        /// </summary>
        /// <param name="aluno">Atualiza um aluno</param>
        public void Atualizar(Aluno aluno)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para atualizar o aluno
                string sqlQuery = "" ;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);   
                   
   
                con.Open();   
                cmd.ExecuteNonQuery();   
                con.Close();   
            }   
        }   
   
        /// <summary>
        /// Busca um aluno pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do aluno a ser mostrado</param> 
        public Aluno BuscarAlunoPorId(int? id)   
        {   
            Aluno aluno = new Aluno();   
   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para buscar o aluno pelo Id
                string sqlQuery = "";   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);   
   
                con.Open();   
                SqlDataReader rdr = cmd.ExecuteReader();   
   
                while (rdr.Read())   
                {   
                    aluno.Id = Convert.ToInt32(rdr["Id"]);   
                    aluno.Nome = rdr["Nome"].ToString();   
                    aluno.Email = rdr["Email"].ToString();   
                    aluno.Sexo = rdr["Sexo"].ToString();
                    aluno.Idade = Convert.ToInt32(rdr["Idade"]);  
                    
                }   
            }   
            return aluno;   
        }   
   
        /// <summary>
        /// Exclui um aluno pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do aluno a ser excluido</param>  
        public void Excluir(int? id)   
        {   
   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para excluir o aluno pelo Id
                string sqlQuery = "";   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);   
   
                con.Open();   
                cmd.ExecuteNonQuery();   
                con.Close();   
            }   
        }   
    }
}