using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    abstract class Cipher
    {
        protected static string alfphabet = "abcdefghijklmnopqrstuvwxyz";

        public int CryptographicResistance;

        abstract public String EncryptMessage(String message);

        abstract public String DecryptMessage(String message);
    }
}
