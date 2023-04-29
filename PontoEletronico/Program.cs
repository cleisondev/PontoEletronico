using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronico
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin vld = new FrmLogin();
            FrmNewUser vld3 = new FrmNewUser();




            if (vld.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
   
            if (vld.ShowDialog() == DialogResult.No)
            {
                Application.Run(new FrmNewUser());
            }






        }
    }
}
