using System;

namespace RSA_WF{
    class RSA {
        Random random = new Random();
        public UserKey generateKeyParis() {
            long p = generateRandomPrim(0, 1000);
            long q = generateRandomPrim(0, 1000);
            long n = p * q;
            long phi = (p - 1) * (q - 1);
            long e = getRandomNumber(1, phi);
            long g = gcd(e, phi);
            while (g != 1) {
                e = getRandomNumber(1, phi);
                g = gcd(e, phi);
            }

            long d = egcd(e, phi)[1];
            d = d % phi;

            if (d < 0) {
                d = d + phi;
            }
            return new UserKey(e,d,n);
        }

        public long generateRandomPrim(int min, int max) {
            while (true) {
                long x = (long) random.Next(min,max);
                if (isPrime(x)) {
                    return x;
                }
            }
        }

        public long getRandomNumber(long min, long max) {
            return random.Next() * (max - min) + min;
        }

        bool isPrime(long num) {
            if (num == 2) {
                return true;
            }

            if (num < 2 || num % 2 == 0) {
                return false;
            }

            for (long n = 3; n < (long)Math.Pow(num, 0.5) + 2; n++) {
                if (num % n == 0) {
                    return false;
                }
            }
            return true;
        }

        long[] egcd(long a, long b) {
            if (a == 0) {
                long[] res = new long[3];
                res[0] = b;
                res[1] = 0;
                res[2] = 1;
                return res;
            } else {
                long[] tabEgcd = new long[3];
                long[] tabResult = new long[3];
                tabEgcd = egcd(b % a, a);
                tabResult[0] = tabEgcd[0];
                tabResult[1] = tabEgcd[2] - (b / a) * tabEgcd[1];
                tabResult[2] = tabEgcd[1];
                return tabResult;
            }
        }

        long gcd(long a, long b) {
            while (b != 0) {
                long x;
                x = a;
                a = b;
                b = x % b;
            }
            return a;
        }
        long modulo(long a, long b, long c) {
            long x = 1;
            long y = a;
            while (b > 0) {
                if (b % 2 == 1) {
                    x = (x * y) % c;
                }
                y = (y * y) % c;
                b /= 2;
            }
            return (long)x % c;
        }
        public long[] encrypt(byte[] bytes, long[] publicKey, MainForm form1) {
            long key = publicKey[0];
            long n = publicKey[1];
            long[] inFutureEncrypt = new long[bytes.Length];
            form1.setUpProgressMax(bytes.Length);
            for (int index = 0; index < bytes.Length; index++) {
                inFutureEncrypt[index] = modulo(bytes[index], key, n);
                form1.setUpProgress(index);
            }
            
            form1.setUpProgress(0);
            key = 0;
            n = 0;
            return inFutureEncrypt;
        }
        public byte[] decrypt(long[] enscrypted, long[] privateKey, MainForm form1) {
            long key = privateKey[0];
            long n = privateKey[1];
            byte[] descrypt = new byte[enscrypted.Length];
            form1.setUpProgressMax(enscrypted.Length);
            for (int index = 0; index < enscrypted.Length; index++) {
                descrypt[index] = (byte)modulo(enscrypted[index], key, n);
                form1.setUpProgress(index);
                //Console.WriteLine(modulo(enscrypted[index], key, n));
            }
            form1.setUpProgress(0);
            return descrypt;
        }
    }
}
