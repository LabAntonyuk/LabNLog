using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NLog
{
    class Log
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public void ProgramStart()
        {
            log.Info("The program was successfully started");
        }

        public void InputError()
        {
            log.Error("Incorrect data entered");
        }

        public void EncryptionSuccess()
        {
            log.Debug("The message is encrypted");
        }

        public void DecryptionSuccess()
        {
            log.Debug("The message is decrypted");
        }

        public void HackSuccess()
        {
            log.Debug("The message is hacked");
        }

        public void ProgramExit()
        {
            log.Info("Program exit");
        }

        
    }
}
