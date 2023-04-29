using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.DAO
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();
        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-7DFKLS9\SQLHOME;Initial Catalog=Projeto_Login;Password='C47541240';Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;

        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
        }

    }
}
