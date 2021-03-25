using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tvs.License.GenrateKey
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = new RSACryptoServiceProvider(1024);

            File.WriteAllText("publicKey.xml", rsa.ToXmlString(false));
            File.WriteAllText("privateKey.xml", rsa.ToXmlString(true));

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}