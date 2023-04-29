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
    public partial class FrmNewUser : Form
    {
        
        public FrmNewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users loguser = new Users();//Instanciando a classe user
            loguser.cadastrar(textBox1.Text, textBox2.Text); //Passando pro verificador da user os params da textbox
            if (loguser.mensagem.Equals("")) //Se não tiver msg, significa que não houve erro, então deu certo.
            {
                if (loguser.tem)//O tem mostra se o login e senha digitado bate com o banco
                {
                    MessageBox.Show("Cadastrado com sucesso", "Efetue o login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMain fmain = new FrmMain();
                    fmain.Show();
                }
                else
                {
                    MessageBox.Show("Cadastro inválido", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(loguser.mensagem);
            }

            //FrmLogin frmLogin = new FrmLogin();
            //frmLogin.Show();
            //this.Hide();
            //MessageBox.Show("Usuário cadastrado");

        }
    }
}
