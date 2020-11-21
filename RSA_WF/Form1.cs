using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_WF
{
    public partial class Form1 : Form{
        Controllers controllers = new Controllers();
        public Form1(){
            InitializeComponent();
        }

        private void generateKeysOnClick(object sender, EventArgs e){
            long[,] keys = new long[2, 2];
            keys = controllers.generateKeys(saveFileDialog1);
            privateKeyTextBox.Text = keys[0, 0].ToString() + "\r\n" + keys[0, 1].ToString();
            publicKeyTextBox.Text = keys[1, 0].ToString() + "\r\n" + keys[1, 1].ToString();
        }



    }
}
