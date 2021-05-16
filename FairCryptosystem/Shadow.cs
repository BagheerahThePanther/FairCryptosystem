﻿using System.Linq;
using System.Numerics;

namespace FairCryptosystem
{
    class Shadow
    {
        protected BigInteger number; // Номер тени
        protected BigInteger value; // Значение тени

        public BigInteger Number
        {
            get { return number; }
            set { number = value; }
        }

        public BigInteger Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Shadow() { }
        public Shadow(BigInteger _number, BigInteger _value)
        {
            number = _number;
            value = _value;
        }
        public byte[] ToByteArray()
        {
            return number.ToByteArray().Concat(value.ToByteArray()).ToArray();
        }
    }
}
