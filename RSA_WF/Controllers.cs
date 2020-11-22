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
        FileManager fileManager = new FileManager();
        //public long[,] keys = new long[2, 2];

        public UserKey generateKeys(System.Windows.Forms.SaveFileDialog saveFileDialog1) {
            String path = fileManager.getPathToSaveFile(saveFileDialog1, rsa, key, "hideMe");
            if (path == null) {
                return rsa.generateKeyParis();
            } else {
                return fileManager.saveKeysToFile(path, rsa, key);
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

        internal void encryptFile(OpenFileDialog openFileDialog1, SaveFileDialog saveFileDialog) {
            //OpenFileDialog openFileDialog = fileManager.getFilePath(openFileDialog1);

            if (fileManager.getFilePath(openFileDialog1,"Select file to encrypt", "All files (*.*)|*.*","").ShowDialog() == DialogResult.OK) {
                String fileName = openFileDialog1.SafeFileName;
                String filePath = openFileDialog1.FileName;
                byte[] data = fileManager.getBytesFromFile(filePath);
                long[] encrypt = rsa.encrypt(data, key.getPublicKey());
                String path = fileManager.getPathToSaveFile(saveFileDialog, null, null, null);
                fileManager.saveDataToFile(path, encrypt, fileName);
            }
        }
        internal void decryptFile(OpenFileDialog openFileDialog1, SaveFileDialog saveFileDialog) {
            if(fileManager.getFilePath(openFileDialog1, "Select file to decrypt", "Encrypted files (*.bin)|*.bin", "").ShowDialog() == DialogResult.OK) {
                String encryptedFilePath = openFileDialog1.FileName;
                String fileName = fileManager.getOriginalNameAndFormat(encryptedFilePath);
                byte[] desc = rsa.decrypt(fileManager.loadDataFromFile(encryptedFilePath), key.getPrivateKey());
                String path = fileManager.getPathToSaveFile(saveFileDialog, null, null, fileName);
                fileManager.createFileFromByte(desc, path);
            }
       
        }



        internal void getKeyFilePath(OpenFileDialog openFileDialog1, string title) {
           fileManager.getKeyFilePath(openFileDialog1, title, key);
        }

        public static void showErrorBox(string title, string message) {
            MessageBox.Show(message, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

     


    }
}
