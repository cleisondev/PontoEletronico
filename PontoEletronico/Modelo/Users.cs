using PontoEletronico.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Modelo
{
    public class Users
    {
        //public string Nome { get; set; }
        //public string Senha { get; set; }

        public bool tem;
        public string mensagem = "";

        public bool acessar(String login, String senha)//O acessar vai receber o login e senha digitado e vai mandar pra logDao
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            tem = loginDao.verificarLog(login, senha);//Aqui ele ta mandando o que eu digitei pro banco validar
            if (!loginDao.mensagem.Equals(""))//
            {
                this.mensagem = loginDao.mensagem;//Se teve erro ele vai entrar aqui e mostrar
            }
            return tem;
        }


        public void cadastrar(String login, String senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            loginDao.cadastrar(login, senha);//Aqui ele ta mandando o que eu digitei pro banco validar
            if (!loginDao.mensagem.Equals(""))//
            {
                this.mensagem = loginDao.mensagem;//Se teve erro ele vai entrar aqui e mostrar
            }
             tem = true;
        }



    }
}
