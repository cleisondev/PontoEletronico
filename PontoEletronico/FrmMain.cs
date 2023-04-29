using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronico
{
    public partial class FrmMain : Form
    {
        //Booleanos pra validar ações
        bool entrou = false;
        bool saiu = false;
        bool almocei = false;
        bool pausei = false;
        bool banheiro = false;

        public FrmMain()
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
            //tipo de marcação
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
            //Mudando pra saída e criando as variáveis de tempo
            button2.Text = "Saída";
            DateTime dia = DateTime.Now;
            string horas = string.Format("{0:T}", dia);
            string hoje = string.Format("{0:d}", dia);

            //Hora de entrar é decidido pela empresa
            int horaDeEntrar = 08;
            if(horaDeEntrar == DateTime.Now.Hour)
            {
                textBox1.Text = $"Entrada hoje às {horas}, Dia:{hoje} ";
                entrou = true;
                comboBox1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Horário de entrada até as 10h");
                button2.Enabled = false;

            }

        }
        //Tipos de pausa 
        private void tipoPausa()
        {
          
            DateTime dia = DateTime.Now;
            string horas = string.Format("{0:T}", dia);
            string volta = string.Format("{0:T}", dia.AddHours(1));
            string voltaPausa = string.Format("{0:T}", dia.AddMinutes(15));
            string hoje = string.Format("{0:d}", dia);
      
           

            //PAUSA ALMOÇO
            if (comboBox1.SelectedItem == "Almoço" && almocei == false )
            {
                almocei = true;
                button1.Text = "Volta almoço";
                textBox1.AppendText(System.Environment.NewLine + $"Saiu para almoçar  às {horas}, volte até às {volta} ");
            }else if(comboBox1.SelectedItem == "Almoço" && almocei == true)
            {

                button1.Text = "Marcar";
                comboBox1.Items.Remove(comboBox1.SelectedItem);
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
                comboBox1.Items.Remove(comboBox1.SelectedItem);
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
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                textBox1.AppendText(System.Environment.NewLine + $"Voltou da pausa de 15 minutos às {volta} ");
            }
        }
        //Chamada pra saída
        private void Sair()
        {
           
            DateTime dia = DateTime.Now;
            string horas = string.Format("{0:T}", dia);
            string hoje = string.Format("{0:d}", dia);

            if(saiu == false)
            {
                button2.Enabled = false;
                MessageBox.Show("Bom descanso...");
            }
          
            textBox1.AppendText (System.Environment.NewLine + $"Saída  às {horas}, Dia:{hoje} ");
            Ler();
 
        }

        //Manda pra um arquivo de texto toda movimentação desse usuário 
        private void  Ler()
        {
           
            string path = @"C:\Temp\myfolder\in.txt";

            try
            {
                string lines = textBox1.Text;
                string[] s = lines.Split(','); 

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("--------------------");
                    foreach(string line in s)
                    {
                        
                        sw.WriteLine(line.ToUpper());
                      
                        
                    }
                    sw.WriteLine("--------------------\n");
                }

            }
            catch (IOException e) { Console.WriteLine("An error ocurred"); Console.WriteLine(e.Message); ; }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
