using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RSA_WF {
    class FileManager {
         public void getKeyFilePath(System.Windows.Forms.OpenFileDialog openFileDialog, String title,UserKey key) {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "Load " + title + " key";
            openFileDialog.RestoreDirectory = true;
            String path;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                //Get the path of specified file
                path = openFileDialog.FileName;
                loadKeyFromFile(path, title,key);
            } else {
                if (title.Equals("private")) {
                    //     key = new UserKey();
                } else if (title.Equals("public")) {
                    //  key = new UserKey();
                }
            }
        }

        void loadKeyFromFile(String path, String title, UserKey key) {
            int counter = 0;
            string line;
            long parsedValue;
            long[] data = new long[2];
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            if (System.IO.File.ReadAllLines(path).Count() == 2) {
                while ((line = file.ReadLine()) != null) {
                    if (long.TryParse(line, out parsedValue)) {
                        data[counter] = Convert.ToInt64(line);
                    }
                    counter++;
                }
                file.Close();
                if (title.Equals("private")) {
                    key.setUpPrivateKey(data[0], data[1]);
                } else if (title.Equals("public")) {
                    key.setUpPublicKey(data[0], data[1]);
                    //key.updatePrivateKey(0, 0);
                }
            } else {
                Controllers.showErrorBox("Error", "Wrong key file");
            }
        }

        public String getPathToSaveFile(System.Windows.Forms.SaveFileDialog saveFileDialog1, RSA rsa, UserKey key,String fileName) {
            saveFileDialog1.FileName = fileName;
            //  saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                return saveFileDialog1.FileName;
            } else {
                return null;
            }
        }

        public UserKey saveKeysToFile(String path, RSA rsa, UserKey key) {
            key = rsa.generateKeyParis();
            if (path != null) {
                System.IO.File.WriteAllText(@path + "privateKey.txt", Convert.ToString(key.getPrivateKey()[0]) +
                    "\n" + Convert.ToString(key.getPrivateKey()[1]) + "\n");
                System.IO.File.WriteAllText(@path + "publicKey.txt", Convert.ToString(key.getPublicKey()[0]) +
                    "\n" + Convert.ToString(key.getPublicKey()[1]) + "\n");
                return key;
            } else {
                return key;
            }
        }

        public OpenFileDialog getFilePath(OpenFileDialog openFileDialog1,String title, String filter,String fileTitle) { 
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = filter;
            openFileDialog1.Title = title;
            openFileDialog1.FileName = fileTitle;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            String fileName = openFileDialog1.SafeFileName;
            return openFileDialog1;
        }

        public byte[] getBytesFromFile(String path) {
            byte[] data = System.IO.File.ReadAllBytes(path);
            return data;
        }

        public void createFileFromByte(byte[] data,String path) {
            File.WriteAllBytes(path, data);
        }

        public void saveDataToFile(String path,long[] longData,String fileName) {
            String[] data = new string[longData.Length + 1];
            for(int index = 0; index < longData.Length; index++) {
                data[index] = Convert.ToString(longData[index]);
            }
            data[longData.Length] = fileName;
             
            System.IO.File.WriteAllLines(path, data);
        }

        public long[] loadDataFromFile(String path) {
            string[] lines = System.IO.File.ReadAllLines(path);
            long[] data = new long[lines.Length];
            int index = 0;
            int number;
            foreach (string line in lines) {
                if(Int32.TryParse(line, out number)) { 
                    data[index] = Convert.ToInt64(line);
                    index++;
                }
            }
               
            return data;
        }

        public String getOriginalNameAndFormat(String path) {
            String name = File.ReadLines(path).Last();
            return name;
        }
    }
}

