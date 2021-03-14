using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Configuration;
using System.Globalization;

namespace DigitalSignatureGOST
{
    class ModularArithmetic
    {
        //private static readonly BigInteger modulus = BigInteger.Parse(ConfigurationManager.AppSettings.Get("Modulus"), new NumberFormatInfo());
        public ModularArithmetic() { }

        public static BigInteger getModulus(BigInteger number, BigInteger modulus)
        {
            if (number >= 0 && number < modulus) return number;
            if (number < 0)
            {
                return (number % modulus) + modulus;
            }
            else return number % modulus;
        }

        public static BigInteger bin_pow(BigInteger _base, BigInteger p, BigInteger modulus)
        {
            _base = getModulus(_base, modulus);
            p = getModulus(p, modulus);
            if (p == 1)
            {
                return _base;    //Выход из рекурсии.
            }

            if (p % 2 == 0)
            {
                BigInteger t = bin_pow(_base, p / 2, modulus);
                return t * t % modulus;
            }
            else
            {
                return bin_pow(_base, p - 1, modulus) * _base % modulus;
            }
        }
        public static BigInteger inverse_element(BigInteger number, BigInteger modulus)
        {
            return bin_pow(number, modulus - 2, modulus);
        }

        //(a / b) mod m
        public static BigInteger divide(BigInteger a, BigInteger b, BigInteger modulus)
        {
            return a * inverse_element(b, modulus) % modulus;
        }

    }
}
