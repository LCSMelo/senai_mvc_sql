using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using cadastro_senai.Dominio;

namespace cadastro_senai.Repositorio
{
    public class ClienteRep
    {
        string connectionString = "Put Your Connection string here";   
   
        /// <summary>
        /// Lista todos os clientes cadastrados
        /// </summary>
        /// <returns>Retorna uma lista do tipo Cliente</returns>
        public List<Cliente> Listar()   
        {   
            List<Cliente> lstCliente = new List<Cliente>();   
   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //SqlCommand cmd = new SqlCommand("spListarCliente", con);   
                //cmd.CommandType = CommandType.StoredProcedure;   
                 
                string sqlQuery = "SELECT * FROM Clientes";   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);   
   
                con.Open();   
                SqlDataReader rdr = cmd.ExecuteReader();   
   
                while (rdr.Read())   
                {   
                    Cliente cliente = new Cliente();   
   
                    cliente.Id = Convert.ToInt32(rdr["Id"]);   
                    cliente.Nome = rdr["Nome"].ToString();   
                    cliente.Email = rdr["Email"].ToString();   
                    cliente.Sexo = rdr["Sexo"].ToString();  
                    cliente.Idade = Convert.ToInt32(rdr["Id"]);   
   
                    lstCliente.Add(cliente);   
                }   
                con.Close();   
            }   
            return lstCliente;   
        }   
   
        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="cliente">Parametro de entrada do tipo Cliente</param>    
        public void Cadastrar(Cliente cliente)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                /*
                SqlCommand cmd = new SqlCommand("spCadastrarCliente", con);   
                cmd.CommandType = CommandType.StoredProcedure;   
   
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);   
                cmd.Parameters.AddWithValue("@Email", cliente.Email);   
                cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                cmd.Parameters.AddWithValue("@Idade", cliente.Idade);  
                */

                string sqlQuery = "insert into Clientes(nome, email,sexo, idade) values('"+cliente.Nome+"','"+cliente.Email+"','"+cliente.Sexo+"',"+ cliente.Idade+")";   
                SqlCommand cmd = new SqlCommand(sqlQuery, con); 

                con.Open();   
                cmd.ExecuteNonQuery();   
                con.Close();   
            }   
        }   
   
        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="cliente">Atualiza um cliente</param>
        public void Atualizar(Cliente cliente)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                SqlCommand cmd = new SqlCommand("spAtualizarCliente", con);   
                cmd.CommandType = CommandType.StoredProcedure;   
   
                cmd.Parameters.AddWithValue("@Id", cliente.Id);   
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);   
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Sexo", cliente.Email);   
                cmd.Parameters.AddWithValue("@Idade", cliente.Idade);   
   
                con.Open();   
                cmd.ExecuteNonQuery();   
                con.Close();   
            }   
        }   
   
        /// <summary>
        /// Busca um cliente pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do cliente a ser mostrado</param> 
        public Cliente BuscarClientePorId(int? id)   
        {   
            Cliente cliente = new Cliente();   
   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                string sqlQuery = "SELECT * FROM Clientes WHERE id= " + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);   
   
                con.Open();   
                SqlDataReader rdr = cmd.ExecuteReader();   
   
                while (rdr.Read())   
                {   
                    cliente.Id = Convert.ToInt32(rdr["Id"]);   
                    cliente.Nome = rdr["Nome"].ToString();   
                    cliente.Email = rdr["Email"].ToString();   
                    cliente.Email = rdr["Sexo"].ToString();
                    cliente.Idade = Convert.ToInt32(rdr["Idade"]);  
                    
                }   
            }   
            return cliente;   
        }   
   
        /// <summary>
        /// Exclui um cliente pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do cliente a ser excluido</param>  
        public void Excluir(int? id)   
        {   
   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                SqlCommand cmd = new SqlCommand("spExcluirCliente", con);   
                cmd.CommandType = CommandType.StoredProcedure;   
   
                cmd.Parameters.AddWithValue("@Id", id);   
   
                con.Open();   
                cmd.ExecuteNonQuery();   
                con.Close();   
            }   
        }   
    }
}