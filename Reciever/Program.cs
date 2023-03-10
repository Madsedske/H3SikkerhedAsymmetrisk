using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                ReadCSPKey csp = new ReadCSPKey();
                string dataToDecrypt = csp.ReadText();

                Console.WriteLine("Reciever");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Encrypted Text = " + dataToDecrypt);
                Console.WriteLine();
                Console.WriteLine("Container navn?");
                string containerName = Console.ReadLine();
                try
                {
                    byte[] decryptedCsp = csp.DecryptData(Convert.FromBase64String(dataToDecrypt), containerName);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Decrypted Text = " + Encoding.Default.GetString(decryptedCsp));
                    Console.WriteLine("--------------------------------");
                }
                catch (Exception)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Kunne ikke finde den rigtige private key....");
                }
                Console.ReadLine();
                Console.Clear();
                //ReadXMLKey read = new ReadXMLKey();
                //Console.WriteLine("Tryk på enter for at indlæse tekst.");
                //Console.ReadLine();
                //string dataToDecrypt = read.ReadText();
                //Console.WriteLine("------------------------------------------------");
                //Console.WriteLine("Tekst som er indlæst:");
                //Console.WriteLine(dataToDecrypt);
                //Console.WriteLine("------------------------------------------------");
                //Console.WriteLine("Tryk på enter for at dekryptere tekst");
                //Console.ReadLine();
                //byte[] decryptedText = read.Decrypt(Convert.FromBase64String(dataToDecrypt));
                //Console.WriteLine(Encoding.UTF8.GetString(decryptedText));
                //Console.ReadLine();
            }

        }
    }
}
