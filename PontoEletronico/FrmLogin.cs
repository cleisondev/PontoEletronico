using PontoEletronico.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronico
{
    public partial class FrmLogin : Form
    {


        public FrmLogin()
        {
            InitializeComponent();

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Users loguser = new Users();//Instanciando a classe user
            loguser.acessar(textBox2.Text, textBox3.Text); //Passando pro verificador da user os params da textbox
            if (loguser.mensagem.Equals("")) //Se não tiver msg, significa que não houve erro, então deu certo.
            {
                if (loguser.tem)//O tem mostra se o login e senha digitado bate com o banco
                {
                    MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMain fmain = new FrmMain();
                    fmain.Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha inválido", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(loguser.mensagem);
            }


          
        }  

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmNewUser users = new FrmNewUser();
            users.Show();
        }
    }
}
