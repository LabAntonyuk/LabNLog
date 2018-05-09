using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    class VigenereChiper : Cipher
    {
        private String key;

        public VigenereChiper(String key)
        {
            this.key = key;
            CryptographicResistance = 1;
        }

        public override String EncryptMessage(String message)
        {

            string encryptedMessage = "";
            int m = alfphabet.Length;
            int k = 0;
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (message[i] == alfphabet[j])
                    {
                        int temp = j + alfphabet.IndexOf(key[k]);
                        while (temp >= m)
                            temp -= m;
                        encryptedMessage = encryptedMessage + alfphabet[temp];
                        k++;
                        if (k >= key.Length)
                            k = 0;
                    }
                }

            }
            return encryptedMessage;
        }

        public override String DecryptMessage(String message)
        {

            string decryptedMessage = "";
            int m = alfphabet.Length;
            int k = 0;
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (message[i] == alfphabet[j])
                    {
                        int temp = j - alfphabet.IndexOf(key[k]);
                        while (temp < 0)
                            temp += m;
                        decryptedMessage = decryptedMessage + alfphabet[temp];
                        k++;
                        if (k >= key.Length)
                            k = 0;
                    }
                }

            }
            return decryptedMessage;
        }
    }
}
