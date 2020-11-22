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

namespace RSA_WF
{
    public partial class Form1 : Form {
        Controllers controllers = new Controllers();

        public Form1() {
            InitializeComponent();
            
        }

        private void generateKeysOnClick(object sender, EventArgs e) {
            controllers.key = controllers.generateKeys(saveFileDialog1);
            printAllKeysInTextBooks();
        }

        private void checkForNumbers(object sender, EventArgs e) {
            updateKeys.Enabled = true;
        }

        private void updateKeysClick(object sender, EventArgs e) {
            controllers.updateKeys(privateKeyTextBox, publicKeyTextBox, updateKeys);
            
            if (controllers.key.checkIfPrivateKeyExist()) {
                decryptButton.Enabled = true;
            } else {
                decryptButton.Enabled = false;
            }

            if (controllers.key.checkIfPublicKeyExist()) {
                encryptButton.Enabled = true;
            } else {
                encryptButton.Enabled = false;
            }
        }


        private void loadKeysClick(object sender, EventArgs e) {
            controllers.getKeyFilePath(openFileDialog1, "public");
            printAllKeysInTextBooks();
            controllers.getKeyFilePath(openFileDialog1, "private");
            printAllKeysInTextBooks();
        }

        void printInPrivateKeyTextBoox(String text) {
            privateKeyTextBox.Text = text;
        }

        void printInPublicKeyTextBoox(String text) {
            publicKeyTextBox.Text = text;
        }

        void printAllKeysInTextBooks() {
            printInPrivateKeyTextBoox(controllers.key.getPrivateKey()[0].ToString() + "\r\n" +
                controllers.key.getPrivateKey()[1].ToString());

            printInPublicKeyTextBoox(controllers.key.getPublicKey()[0].ToString() + "\r\n" +
                controllers.key.getPublicKey()[1].ToString());

            if (controllers.key.checkIfPrivateKeyExist()) {
                decryptButton.Enabled = true;
            }

            if (controllers.key.checkIfPublicKeyExist()) {
                encryptButton.Enabled = true;
            }
        }

        private void encryptClick(object sender, EventArgs e) {
            controllers.encryptFile(openFileDialog1, saveFileDialog1);


        }

        private void decryptClick(object sender, EventArgs e) {
            controllers.decryptFile(openFileDialog1, saveFileDialog1);
            
        }
    }

                            
        

}
