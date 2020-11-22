using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_WF {
    class UserKey {
        private long[] privateKey = new long[2];
        private long[] publicKey = new long[2];
        public UserKey(long e, long d, long n) {
            this.privateKey[0] = d;
            this.privateKey[1] = n;
            this.publicKey[0] = e;
            this.publicKey[1] = n;
        }

        public UserKey() {
   
        }

        public long[] getPublicKey() {
            return publicKey;
        }

        public long[] getPrivateKey() {
            return privateKey;
        }

        public void updatePublicKey(long e, long n) {
            this.publicKey[0] = e;
            this.publicKey[1] = n;
        }

        public void updatePrivateKey(long d, long n) {
            this.privateKey[0] = d;
            this.privateKey[1] = n;
        }

        public void setUpPublicKey(long e, long n) {
            this.publicKey[0] = e;
            this.publicKey[1] = n;
        }

        public void setUpPrivateKey(long d, long n) {
            this.privateKey[0] = d;
            this.privateKey[1] = n;    
        }

        public void printKeys() {
            Console.WriteLine("Public: " + publicKey[0] + " "+ publicKey[1] + "\n" +
                "Private: " + privateKey[0] + " " + privateKey[1]);
        }

        public bool checkIfPublicKeyExist() {
            long[] key = getPublicKey();
            if (key[0] != 0 && key[1] != 0) {
                return true;
            } else {
                return false;
            }
        }
        public bool checkIfPrivateKeyExist() {
            long[] key = getPrivateKey();
            if (key[0] != 0 && key[1] != 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
