using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Configuration;
using System.Globalization;

namespace FairCryptosystem
{
    class EllipticCurvePoint
    {
        private BigInteger x;
        private BigInteger y;
        private BigInteger a = BigInteger.Parse(ConfigurationManager.AppSettings.Get("a"), new NumberFormatInfo());
        private BigInteger p = BigInteger.Parse(ConfigurationManager.AppSettings.Get("p"), new NumberFormatInfo());

        private bool isZero = false;

        public BigInteger X
        {
            get { return x; }
            set { x = value; }
        }

        public BigInteger Y
        {
            get { return y; }
            set { y = value; }
        }

        public EllipticCurvePoint()
        {
            isZero = true;
        }
        public EllipticCurvePoint(BigInteger X, BigInteger Y)
        {
            x = X; y = Y;
            isZero = false;
        }

        public EllipticCurvePoint multiply(BigInteger multiplier)
        {
            // сначала сложить с собой, поделить множитель на 2, запомнить остаток 1
            // как одну исходную точку, которой не нашлось пары в сложении
            // потом сложить полученное сложение с собой, поделить множитель еще раз на 2
            // сохранив остаток от деления 1 как сложенная с собой точка, которой не нашлось такой же пары

            EllipticCurvePoint tmp = this;
            EllipticCurvePoint sum = new EllipticCurvePoint();
            int numberOfOperations = ((int)BigInteger.Log(multiplier, 2));

            BigInteger tmpMult = multiplier;
            for(int i = 0; i < numberOfOperations; i++)
            {
                if (tmpMult % 2 == 1)
                {
                    sum = sum.add(tmp);
                }
                tmp = tmp.add(tmp);
                tmpMult /= 2;
            }

            return sum.add(tmp);
        }

        public EllipticCurvePoint add(EllipticCurvePoint point)
        {
            if (isZero)
            {
                return point;
            }
            if (point.isZero)
            {
                return this;
            }
            if (x == point.X && y == ModularArithmetic.getModulus(-point.Y, p)) return new EllipticCurvePoint();
            BigInteger lambda = calculateLambda(this, point);
            BigInteger x3 = ModularArithmetic.getModulus(ModularArithmetic.bin_pow(lambda, 2, p) - x - point.X, p);
            return new EllipticCurvePoint(x3, ModularArithmetic.getModulus(lambda * ModularArithmetic.getModulus(x - x3, p) - y, p));
        }
        public BigInteger calculateLambda(EllipticCurvePoint point1, EllipticCurvePoint point2)
        {
            if (point1.X != point2.X)
            {
                return ModularArithmetic.divide(point2.Y - point1.Y, point2.X - point1.X, p);
            }
            if (point1.X == point2.X && point1.Y == point2.Y && point1.Y != 0)
            {
                return ModularArithmetic.divide(3 * ModularArithmetic.bin_pow(point1.X, 2, p) + point1.a, 2 * point1.Y, p);
            }
            throw new Exception("Лямбду надо посчитать, но по условию нельзя");
            return -1;
        }
    }
}
