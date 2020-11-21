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
            controllers.key = controllers.generateKeys(saveFileDialog1);

            privateKeyTextBox.Text = controllers.key.getPrivateKey()[0].ToString() + "\r\n" + 
                controllers.key.getPrivateKey()[1].ToString();

            publicKeyTextBox.Text = controllers.key.getPublicKey()[0].ToString() + "\r\n" + 
                controllers.key.getPrivateKey()[1].ToString();
        }

        private void checkForNumbers(object sender, EventArgs e) {
            updateKeys.Enabled = true;
        }

        private void updateKeysClick(object sender, EventArgs e) {
            controllers.updateKeys(privateKeyTextBox,publicKeyTextBox,updateKeys);
        }


        private void loadKeysClick(object sender, EventArgs e) {
            controllers.key.printKeys();
        }
    }
}
