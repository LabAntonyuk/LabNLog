using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    [DeveloperAttribute("Ekaterina Antonyuk", 23)]
    [ProgramAttribute("Encryption Methods", "A program that allows you to encrypt a message in three different ways")]
    class Program
    {
        private static Log log = new Log();

        public static void GetDeveloperAttribute(Type t)
        {
            DeveloperAttribute newAttribute =
             (DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

            if (newAttribute == null)
            {
                Console.WriteLine("Attribute not found");
            }
            else
            {
                Console.WriteLine("Developer: ");
                Console.WriteLine("Developer: {0}", newAttribute.DeveloperName);
                Console.WriteLine("Age: {0}\n", newAttribute.DeveloperAge);
            }
        }

        public static void GetProgramAttribute(Type t)
        {
            DeveloperAttribute newAttribute =
             (DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

            if (newAttribute == null)
            {
                Console.WriteLine("Attribute not found");
            }
            else
            {
                Console.WriteLine("Program: ");
                Console.WriteLine("Name: {0}", newAttribute.DeveloperName);
                Console.WriteLine("Info: {0}\n", newAttribute.DeveloperAge);
            }
        }

        static void Main(string[] args)
        {
            GetDeveloperAttribute(typeof(Program));
            log.ProgramStart();
            Ciphers();
        }

        private static void Ciphers()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("Выберите шифр:\n 1 - Шифр Цезаря\n 2 - Аффинный шифр\n 3 - Шифр Виженера\n esc - Выйти");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("\nВыберите действие:\n 1 - Зашифровать сообщение\n " +
                        "2 - Расшифровать сообщение\n 3 - Дешифровать сообщение");
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.D1)
                    {
                        CaesarEncrypt();
                        log.EncryptionSuccess();
                        Console.ReadKey();
                    }
                    if (cki.Key == ConsoleKey.D2)
                    {
                        CaesarDecrypt();
                        log.EncryptionSuccess();
                        Console.ReadKey();
                    }
                    if (cki.Key == ConsoleKey.D3)
                    {
                        CaesarHack();
                        log.HackSuccess();
                        Console.ReadKey();
                    }
                }

                if (cki.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("\nВыберите действие:\n 1 - Зашифровать сообщение\n 2 - Расшифровать сообщение\n");
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.D1)
                    {
                        AffineEncrypt();
                        log.EncryptionSuccess();
                        Console.ReadKey();
                    }
                    if (cki.Key == ConsoleKey.D2)
                    {
                        AffineDecrypt();
                        log.DecryptionSuccess();
                        Console.ReadKey();
                    }
                }

                if (cki.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("\nВыберите действие:\n 1 - Зашифровать сообщение\n 2 - Расшифровать сообщение\n");
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.D1)
                    {
                        VigenereEncrypt();
                        log.EncryptionSuccess();
                        Console.ReadKey();
                    }
                    if (cki.Key == ConsoleKey.D2)
                    {
                        VigenereDecrypt();
                        log.DecryptionSuccess();
                        Console.ReadKey();
                    }
                }
            } while (cki.Key != ConsoleKey.Escape);
            log.ProgramExit();
        }

        private static void CaesarEncrypt()
        {
            Console.WriteLine("Input your message to encrypt (in English and without punctuation)");
            string message = Console.ReadLine().ToLower();
            message = message.Replace(" ", string.Empty);
            Console.WriteLine("Input key");
            int key = ParseKey();
            var Caesar1 = new CaesarCipher(key);
            Console.WriteLine(Caesar1.EncryptMessage(message));
        }

        

        private static void CaesarDecrypt()
        {
            Console.WriteLine("Input your message to decrypt");
            string message = Console.ReadLine();
            Console.WriteLine("Input key");
            int key = ParseKey();
            var Caesar2 = new CaesarCipher(key);
            Console.WriteLine(Caesar2.DecryptMessage(message));
        }

        private static void CaesarHack()
        {
            Console.WriteLine("Input your message to hack");
            string message = Console.ReadLine();
            Console.WriteLine("Variants:");
            CaesarCipher.HackMessage(message);
        }

        private static void AffineEncrypt()
        {
            Console.WriteLine("Input your message to encrypt (in English and without punctuation)");
            string message = Console.ReadLine().ToLower();
            message = message.Replace(" ", string.Empty);
            Console.WriteLine("Input key a (must be relatively prime to the volume of the alphabet)");
            int a = ParseKey();
            Console.WriteLine("Input key b");
            int b = ParseKey();
            var Affine1 = new AffineCipher(a, b);
            Console.WriteLine(Affine1.EncryptMessage(message));
        }

        private static void AffineDecrypt()
        {
            Console.WriteLine("Input your message to decrypt");
            string message = Console.ReadLine();
            Console.WriteLine("Input key a");
            int a = ParseKey();
            Console.WriteLine("Input key b");
            int b = ParseKey();

            var Affine2 = new AffineCipher(a, b);

            Console.WriteLine(Affine2.DecryptMessage(message));
        }

        private static void VigenereEncrypt()
        {
            Console.WriteLine("Input your message to encrypt (in English and without punctuation)");
            string message = Console.ReadLine().ToLower();
            message = message.Replace(" ", string.Empty);
            Console.WriteLine("Input key");
            string key = Console.ReadLine();
            var Vigenere1 = new VigenereChiper(key);
            Console.WriteLine(Vigenere1.EncryptMessage(message));
        }

        private static void VigenereDecrypt()
        {
            Console.WriteLine("Input your message to decrypt");
            string message = Console.ReadLine();
            Console.WriteLine("Input key");
            string key = Console.ReadLine();
            var Vigenere1 = new VigenereChiper(key);
            Console.WriteLine(Vigenere1.DecryptMessage(message));

        }

        private static int ParseKey()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("The key must be a number. Input anoyher key");
                log.InputError();
                return ParseKey();
            }
        }
    }
}
