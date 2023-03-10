using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace H3SikkerhedAsymmetrisk
{
    public class CSPKey
    {
        string ContainerName = "MyContainer";
        public void CreateKey()
        {
            CspParameters para = new CspParameters(1);
            para.KeyContainerName = ContainerName;
            para.Flags = CspProviderFlags.UseMachineKeyStore;
            para.ProviderName = "Microsoft Strong Cryptographic Provider";
            var rsa = new RSACryptoServiceProvider(para) { PersistKeyInCsp = true };
        }

        public void SaveText(byte[] encryptedText)
        {
            string encryptedTextFile = "c:\\Programmering\\encryptedText.txt";
            File.WriteAllText(encryptedTextFile, Convert.ToBase64String(encryptedText));
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] encryptedText;
            var para = new CspParameters { KeyContainerName = ContainerName };
            using (var rsa = new RSACryptoServiceProvider(2048, para))
            {
                encryptedText = rsa.Encrypt(dataToEncrypt, false);
            }
            return encryptedText;
        }
    }
}
