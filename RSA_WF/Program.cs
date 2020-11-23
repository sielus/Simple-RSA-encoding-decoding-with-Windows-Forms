using System;
using System.Windows.Forms;

namespace RSA_WF
{
    static class Program
    {
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
