using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    class AffineCipher : Cipher
    {
        private int a;
        private int b;

        public AffineCipher(int a, int b)
        {
            this.a = a;
            this.b = b;
            CryptographicResistance = 2;
        }
        public override String EncryptMessage(String message)
        {
            string encryptedMessage = "";
            int m = alfphabet.Length;
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (message[i] == alfphabet[j])
                    {
                        int temp = a * j + b;
                        while (temp >= m)
                            temp -= m;
                        encryptedMessage = encryptedMessage + alfphabet[temp];
                    }
                }

            }
            return encryptedMessage;
        }

        public override String DecryptMessage(String message)
        {

            string decryptedMessage = "";
            int m = alfphabet.Length;
            int n = 1;
            int t = 0;
            while (n != 0)
            {
                t++;
                n = (m * t + 1) % a;
            }
            int a1 = (m * t + 1) / a;
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (message[i] == alfphabet[j])
                    {
                        int temp = a1 * (j - b);
                        while (temp <= 0)
                            temp += m;
                        while (temp >= m)
                            temp -= m;
                        decryptedMessage = decryptedMessage + alfphabet[temp];
                    }
                }

            }
            return decryptedMessage;
        }

    }
}
