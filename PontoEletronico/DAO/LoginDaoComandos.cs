using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.DAO
{
    class LoginDaoComandos
    {
        public bool tem = false;
        public string mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool verificarLog(String login, String senha)//Verificando se a senha do txtbox bate com o banco
        {
            //Usando um comando de seleção
            cmd.CommandText = "select * from Usuarios where users = @login and senha = @senha";

            //Passando pra seleção a relação dos valores
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                //Conectando
                cmd.Connection = con.Conectar();
                //Buscando a infromação do select e guardando no reader
                dr = cmd.ExecuteReader();
                if (dr.HasRows)//Se tiver linhas retorna true
                {
                    tem = true;
                }
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com Banco de dados";
            }
            return tem;
        }

        public void cadastrar(String login, String senha)
        {
            cmd.CommandText = "insert into Usuarios values( @login, @senha)";

            //Passando pra seleção a relação dos valores
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                //Conectando
                cmd.Connection = con.Conectar();
                //Buscando a infromação do select e guardando no reader
                cmd.ExecuteNonQuery();
                
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com Banco de dados";
            }
            
        }
    }
}
