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
        private readonly BigInteger modulus = BigInteger.Parse(ConfigurationManager.AppSettings.Get("Modulus"), new NumberFormatInfo());
        private readonly uint keyLengthInBytes = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("KeyLengthInBytes"));
        private readonly uint shadowNumberLengthInBytes = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("ShadowNumberLengthInBytes"));

        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public SecretSharing() { }
        public BigInteger generateNumber(uint lengthInBytes)
        {
            BigInteger number;
            byte[] randomNumber = new byte[lengthInBytes];
            rngCsp.GetBytes(randomNumber);
            number = new BigInteger(randomNumber);
            return getModulus(number);
        }

        public Shadow[] computeShadows(BigInteger secret, int numberOfShadows)
        {
            if (numberOfShadows < 1) return null;
            Shadow[] shadows = new Shadow[numberOfShadows];
            for(int i = 0; i < numberOfShadows; i++)
            {
                shadows[i] = new Shadow();
            }

            BigInteger coefficientA = getModulus(generateNumber(keyLengthInBytes));
            //  BigInteger currentNumber = 1;
            BigInteger currentNumber = generateNumber(shadowNumberLengthInBytes);
            foreach (Shadow shadow in shadows)
            {
                BigInteger newValue = getModulus((coefficientA * currentNumber) + secret);
                shadow.Number = currentNumber;
                shadow.Value = newValue;
                Console.WriteLine(secret.ToString() + " " + coefficientA.ToString() + " " + currentNumber.ToString() + " " + newValue.ToString());
                //currentNumber++;
                currentNumber = generateNumber(shadowNumberLengthInBytes);
            }
            return shadows;
        }

        public BigInteger restoreSecret(Shadow[] shadows)
        {
            if (shadows.Length < 2) return -1;
            return divide(getModulus(shadows[1].Value * shadows[0].Number - shadows[0].Value * shadows[1].Number), getModulus(shadows[0].Number - shadows[1].Number));
        }

        public BigInteger getModulus(BigInteger number)
        {
            if (number >= 0 && number < modulus) return number;
            if(number < 0)
            {
              return (number % modulus) + modulus;
            } else return number % modulus;
        }

        public BigInteger bin_pow(BigInteger _base, BigInteger p)
        {
            _base = getModulus(_base);
            p = getModulus(p);
            if (p == 1)
            {
                return _base;    //Выход из рекурсии.
            }

            if (p % 2 == 0)
            {
                BigInteger t = bin_pow(_base, p / 2);
                return t * t % modulus;
            }
            else
            {
                return bin_pow(_base, p - 1) * _base % modulus;
            }
        }
        BigInteger inverse_element(BigInteger number)
        {
            return bin_pow(number, modulus - 2);
        }

        //(a / b) mod m
        BigInteger divide(BigInteger a, BigInteger b)
        {
            return a * inverse_element(b) % modulus;
        }
    }
}
