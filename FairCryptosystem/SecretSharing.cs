using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Configuration;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;

namespace FairCryptosystem
{
    class SecretSharing
    {
        private BigInteger modulus = BigInteger.Parse(ConfigurationManager.AppSettings.Get("Modulus"), new NumberFormatInfo());
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public SecretSharing() { }
        public BigInteger generateNumber(int lengthInBytes)
        {
            byte[] randomNumber = new byte[lengthInBytes];
            rngCsp.GetBytes(randomNumber);
            return new BigInteger(randomNumber);
        }

    }
}
