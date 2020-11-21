using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_WF
{
    class Controllers{
        private RSA rsa = new RSA();

        public long [,] generateKeys(System.Windows.Forms.SaveFileDialog saveFileDialog1) {
            return getPathToSaveFile(saveFileDialog1);
        }


        public long[,] getPathToSaveFile(System.Windows.Forms.SaveFileDialog saveFileDialog1) {
            saveFileDialog1.FileName = "hideMe";
          //  saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK){
                return saveKeysToFile(saveFileDialog1.FileName);
            } else {
                return rsa.generateKeyParis();
            }
        }

        public long[,] saveKeysToFile(String path) {
            long[,] keys = rsa.generateKeyParis();
            if(path != null) {
                System.IO.File.WriteAllText(@path + "privateKey.txt", Convert.ToString(keys[0, 0]) +
                    "\n" + Convert.ToString(keys[0, 1]) + "\n");
                System.IO.File.WriteAllText(@path + "publicKey.txt", Convert.ToString(keys[1, 0]) +
                    "\n" + Convert.ToString(keys[1, 1]) + "\n");
                return keys;
            } else {
                return keys;
            }


        }
    }
}
