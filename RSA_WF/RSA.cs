using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            long[,] result = new long[2, 2];
            result[0, 0] = e;
            result[0, 1] = n;
            result[1, 0] = d;
            result[1, 1] = n;

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
    }
}
