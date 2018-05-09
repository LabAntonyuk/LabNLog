using System;

public class Class1
{
    class CaesarCipher : Cipher
    {
        public int key;
        public CaesarCipher(int key)
        {
            this.key = key;
            CryptographicResistance = 3;
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
                        int temp = j + key;
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
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (message[i] == alfphabet[j])
                    {
                        int temp = j - key;
                        while (temp < 0)
                            temp += m;
                        decryptedMessage = decryptedMessage + alfphabet[temp];
                    }
                }

            }
            return decryptedMessage;
        }

        public static void HackMessage(String message)
        {
            int m = alfphabet.Length;
            for (int key = 1; key < alfphabet.Length; key++)
            {
                string hackedMessage = "";
                for (int i = 0; i < message.Length; i++)
                {
                    for (int j = 0; j < alfphabet.Length; j++)
                    {
                        if (message[i] == alfphabet[j])
                        {
                            int temp = j - key;
                            while (temp < 0)
                                temp += m;
                            hackedMessage = hackedMessage + alfphabet[temp];
                        }
                    }
                }
                Console.WriteLine("Key = {0} Message: {1}", key, hackedMessage);
            }
        }

    }
}
