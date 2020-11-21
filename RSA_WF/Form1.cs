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
        long[,] keys = new long[2, 2];
        Controllers controllers = new Controllers();
        public Form1(){
            InitializeComponent();
        }

        private void generateKeysOnClick(object sender, EventArgs e){
            
            keys = controllers.generateKeys(saveFileDialog1);
            privateKeyTextBox.Text = keys[0, 0].ToString() + "\r\n" + keys[0, 1].ToString();
            publicKeyTextBox.Text = keys[1, 0].ToString() + "\r\n" + keys[1, 1].ToString();
           
   
        }

        private void checkForNumbers(object sender, EventArgs e) {
            updateKeys.Enabled = true;
        }

        private void updateKeysClick(object sender, EventArgs e) {
            bool checkPrivate = false;
            bool checkPublic = false;
            long[] privateKey = new long[privateKeyTextBox.Lines.Length];
            long parsedValue;
            if (privateKeyTextBox.Lines.Length == 2) {
                if(long.TryParse(privateKeyTextBox.Lines[0], out parsedValue) && 
                    long.TryParse(privateKeyTextBox.Lines[1], out parsedValue)){
                    for (int index = 0; index < privateKey.Length; index++) {
                        privateKey[index] = Convert.ToInt64(privateKeyTextBox.Lines[index]);
                    }
                    checkPrivate = true;
                    keys[1, 0] = privateKey[0];
                    keys[1, 1] = privateKey[1];
                } else{
                    showErrorBox("Wrong private key", "Lines 1 or 2 is wrong");
                }
            }else{
                showErrorBox("Wrong private key", "Private key can have max 2 lines");
            }

            long[] publicKey = new long[publicKeyTextBox.Lines.Length];
            if (publicKeyTextBox.Lines.Length == 2) {
                if (long.TryParse(publicKeyTextBox.Lines[0], out parsedValue) &&
                    long.TryParse(publicKeyTextBox.Lines[1], out parsedValue)) {
                    for (int index = 0; index < publicKey.Length; index++) {
                        publicKey[index] = Convert.ToInt64(publicKeyTextBox.Lines[index]);
                    }
                    checkPublic = true;
                    keys[0, 0] = publicKey[0];
                    keys[0, 1] = publicKey[1];
                } else {
                    showErrorBox("Wrong public key", "Lines 1 or 2 is wrong");
                }
            } else {
                showErrorBox("Wrong public key", "Public key can have max 2 lines");
            }

            if(checkPublic && checkPrivate) {
                updateKeys.Enabled = false;
            }
        }

        private void showErrorBox(string title, string message) {
            MessageBox.Show(message, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        private void loadKeysClick(object sender, EventArgs e) {
            Console.WriteLine(keys[0,0]);
            Console.WriteLine(keys[0, 1]);
            Console.WriteLine(keys[1, 0]);
            Console.WriteLine(keys[1, 1]);
        }
    }
}
