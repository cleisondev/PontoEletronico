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
    public partial class Form1 : Form
    {
        int btnClicks = 0;
        bool almocei = false;
        bool pausei = false;
        bool banheiro = false;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                tipoPausa();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Entrada")
            {
                Entrar();
            }
            else
            {
                Sair();
            }
        }


        private void Entrar()
        {
            button2.Text = "Saída";
            DateTime dia = DateTime.Now;
            string horas = string.Format("{0:T}", dia);
            string hoje = string.Format("{0:d}", dia);

            int horaDeEntrar = 18;
            if(horaDeEntrar == DateTime.Now.Hour)
            {
                textBox1.Text = $"Entrada hoje às {horas}, Dia:{hoje} ";
                comboBox1.Enabled = true;
            }
            else
            {
                textBox1.Text = $"Horário de entrada até as 10:00";
            }

        }

        private void tipoPausa()
        {
          
            DateTime dia = DateTime.Now;
            string horas = string.Format("{0:T}", dia);
            string volta = string.Format("{0:T}", dia.AddHours(1));
            string voltaPausa = string.Format("{0:T}", dia.AddMinutes(15));
            string hoje = string.Format("{0:d}", dia);
           

            //PAUSA ALMOÇO
            if (comboBox1.SelectedItem == "Almoço" && almocei == false)
            {
                almocei = true;
                button1.Text = "Volta almoço";
                textBox1.AppendText(System.Environment.NewLine + $"Saiu para almoçar  às {horas}, volte até às {volta} ");
            }else if(comboBox1.SelectedItem == "Almoço" && almocei == true)
            {
                button1.Text = "Marcar";
                textBox1.AppendText(System.Environment.NewLine + $"Voltou do almoço  às {horas} ");
            }

            //PAUSA BANHEIRO
            if (comboBox1.SelectedItem == "Banheiro" && banheiro == false)
            {
                banheiro = true;
                button1.Text = "Volta banheiro";
                textBox1.AppendText(System.Environment.NewLine + $"Pausa para ir ao banheiro");
            }
            else if (comboBox1.SelectedItem == "Banheiro" && banheiro == true)
            {
                button1.Text = "Marcar";
                textBox1.AppendText(System.Environment.NewLine + $"Voltou da pausa banheiro");
            }

            //PAUSA DE 15 MINUTOS
            if (comboBox1.SelectedItem == "Pausa" && pausei == false)
            {
                pausei = true;
                button1.Text = "Pausa 15 min";
                textBox1.AppendText(System.Environment.NewLine + $"Pausa de 15 minutos , retorne até às {voltaPausa} ");
            }
            else if (comboBox1.SelectedItem == "Pausa" && pausei == true)
            {
                button1.Text = "Marcar";
                textBox1.AppendText(System.Environment.NewLine + $"Voltou da pausa de 15 minutos às {volta} ");
            }
        }

        private void Sair()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            DateTime dia = DateTime.Now;
            string horas = string.Format("{0:T}", dia);
            string hoje = string.Format("{0:d}", dia);

          
            textBox1.AppendText (System.Environment.NewLine + $"Saída  às {horas}, Dia:{hoje} ");
 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}
