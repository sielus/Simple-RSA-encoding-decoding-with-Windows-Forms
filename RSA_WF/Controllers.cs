using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_WF
{
    class Controllers{
        private RSA rsa = new RSA();
        public UserKey key = new UserKey();
        //public long[,] keys = new long[2, 2];

        public UserKey generateKeys(System.Windows.Forms.SaveFileDialog saveFileDialog1) {
            return getPathToSaveFile(saveFileDialog1);
        }

        public UserKey getPathToSaveFile(System.Windows.Forms.SaveFileDialog saveFileDialog1) {
            saveFileDialog1.FileName = "hideMe";
          //  saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK){
                return saveKeysToFile(saveFileDialog1.FileName);
            } else {
                return rsa.generateKeyParis();
            }
        }

        public UserKey saveKeysToFile(String path) {
            key = rsa.generateKeyParis();
            if(path != null) {
                System.IO.File.WriteAllText(@path + "privateKey.txt", Convert.ToString(key.getPrivateKey()[0]) +
                    "\n" + Convert.ToString(key.getPrivateKey()[0]) + "\n");
                System.IO.File.WriteAllText(@path + "publicKey.txt", Convert.ToString(key.getPublicKey()[0]) +
                    "\n" + Convert.ToString(key.getPublicKey()[1]) + "\n");
                return key;
            } else {
                return key;
            }
        }

        public void updateKeys(TextBox privateKeyTextBox, TextBox publicKeyTextBox, Button updateKeys) {
            bool checkPrivate = false;
            bool checkPublic = false;
            long[] privateKey = new long[privateKeyTextBox.Lines.Length];
            long parsedValue;
            if (privateKeyTextBox.Lines.Length == 2) {
                if (long.TryParse(privateKeyTextBox.Lines[0], out parsedValue) &&
                    long.TryParse(privateKeyTextBox.Lines[1], out parsedValue)) {
                    for (int index = 0; index < privateKey.Length; index++) {
                        privateKey[index] = Convert.ToInt64(privateKeyTextBox.Lines[index]);
                    }
                    checkPrivate = true;
                    key.updatePrivateKey(privateKey[0], privateKey[1]);
                } else {
                    showErrorBox("Wrong private key", "Lines 1 or 2 is wrong");
                }
            } else {
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
                    key.updatePublicKey(publicKey[0], publicKey[1]);
                } else {
                    showErrorBox("Wrong public key", "Lines 1 or 2 is wrong");
                }
            } else {
                showErrorBox("Wrong public key", "Public key can have max 2 lines");
            }

            if (checkPublic && checkPrivate) {
                updateKeys.Enabled = false;
            }
        }
        private void showErrorBox(string title, string message) {
            MessageBox.Show(message, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void getFilePath(System.Windows.Forms.OpenFileDialog openFileDialog,String title) {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "Load " + title + " key";
            openFileDialog.RestoreDirectory = true;
            String path;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                //Get the path of specified file
                path = openFileDialog.FileName;
                loadKeyFromFile(path,title);
            } else {
                if (title.Equals("private")) {
               //     key = new UserKey();
                } else if (title.Equals("public")) {
                  //  key = new UserKey();
                }
            }
        }

        void loadKeyFromFile(String path,String title) {
            int counter = 0;
            string line;
            long parsedValue;
            long[] data = new long[2];
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            if(File.ReadAllLines(path).Count() == 2) {
                while ((line = file.ReadLine()) != null) {
                    if (long.TryParse(line, out parsedValue)) {
                        data[counter] = Convert.ToInt64(line);
                    }
                    counter++;
                }
                file.Close();

                if (title.Equals("private")) {
                    Console.WriteLine(data[0] + " private " + data[1]);
                    key.setUpPrivateKey(data[0], data[1]);
                    key.printKeys();
                } else if (title.Equals("public")) {
                    Console.WriteLine(data[0] + " public " + data[1]);
                    key.setUpPublicKey(data[0], data[1]);
                    key.updatePrivateKey(0, 0);

                    key.printKeys();
                }
            } else {
                showErrorBox("Error", "Wrong key file");
            }
        }

    }
}
