using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Configuration;
using System.Globalization;
using System.Security.Cryptography;


namespace KeyRestoration
{
    class GOSTSignature
    {
        // Из конфига берутся параметры алгоритма
        private BigInteger a = BigInteger.Parse(ConfigurationManager.AppSettings.Get("a"), new NumberFormatInfo());
        private BigInteger b = BigInteger.Parse(ConfigurationManager.AppSettings.Get("b"), new NumberFormatInfo());
        private BigInteger p = BigInteger.Parse(ConfigurationManager.AppSettings.Get("p"), new NumberFormatInfo());
        private BigInteger J;
        private BigInteger K = 0;
        private BigInteger m = BigInteger.Parse(ConfigurationManager.AppSettings.Get("m"), new NumberFormatInfo());
        private BigInteger q = BigInteger.Parse(ConfigurationManager.AppSettings.Get("q"), new NumberFormatInfo());
        private BigInteger Px = BigInteger.Parse(ConfigurationManager.AppSettings.Get("Px"), new NumberFormatInfo());
        private BigInteger Py = BigInteger.Parse(ConfigurationManager.AppSettings.Get("Py"), new NumberFormatInfo());
        private BigInteger D = BigInteger.Parse(ConfigurationManager.AppSettings.Get("d"), new NumberFormatInfo());
        private BigInteger Qx = BigInteger.Parse(ConfigurationManager.AppSettings.Get("Qx"), new NumberFormatInfo());
        private BigInteger Qy = BigInteger.Parse(ConfigurationManager.AppSettings.Get("Qy"), new NumberFormatInfo());

        // Штука для генерации массива случайных байт
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public GOSTSignature()
        {
            // В госте есть проверка корректности q, так что почему бы и нет
            if (!isQCorrect())
            {
                throw new ArgumentException("Порядок циклической подгруппы точек неверен", "q");
            }
        }
        public bool isQCorrect()
        {
            // Большие страшные числа - это границы значения q из стандарта. Можно было вынести их в константы, но мне лень. 
            if (m % q == 0
                && (q > BigInteger.Parse("28948022309329048855892746252171976963317496166410141009864396001978282409984") 
                && q < BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007913129639936") 
                || q > BigInteger.Parse("837987995621412318723376562387865382967460363787024586107722590232610251879596686050117143635431464230626991136655378178359617675746660621652103062880256") 
                && q < BigInteger.Parse("13407807929942597099574024998205846127479365820592393377723561443721764030073546976801874298166903427690031858186486050853753882811946569946433649006084096")))
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool isHash256()
        {
            // Если q из одного диапазона, то применяется 256-битный хэш, иначе длина хэша 512
            // Так как проверка на правильность q есть в конструкторе, то можно проверить по одной границе к какому диапазону он принадлежит
            if(q < BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007913129639936"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public BigInteger generateNumber()
        {
            BigInteger number;
            byte[] randomNumber = new byte[64];
            rngCsp.GetBytes(randomNumber);
            // Нулевой байт в конец добавляется для того, чтобы конструктор BigInteger воспринял число как положительное
            number = new BigInteger(randomNumber.Concat(new byte[] { 0 }).ToArray());
            return number;
        }

        public byte[] createDigitalSignature(byte[] message)
        {
            // Простое решение чтобы подписывать на ключе из конфига не меняя много кода
            return createDigitalSignature(message, D.ToByteArray());
        }

        public byte[] createDigitalSignature(byte[] message, byte[] privateKey)
        {

            BigInteger d = new BigInteger(privateKey.Concat(new byte[] { 0 }).ToArray());

            // Шаг 1 - Вычисление хэша
            byte[] hash = GOSTHash.createHash(message, isHash256());

            // Пример из стандарта для теста:
            // byte[] hash = BigInteger.Parse("20798893674476452017134061561508270130637142515379653289952617252661468872421").ToByteArray();

            // Шаг 2 - вычисление e
            // e = h (mod q), если e = 0, то e = 1
            BigInteger e = new BigInteger(hash.Concat(new byte[] { 0 }).ToArray()) % q;

            // Пример из стандарта для теста:
            // BigInteger e = BigInteger.Parse("20798893674476452017134061561508270130637142515379653289952617252661468872421");

            if (e == 0) e = 1; 
           
            // Вспомогательные переменные, названы как в госте
            BigInteger r = 0;
            BigInteger s = 0;
            BigInteger k = 0;
            //

            // хитрые циклы, которые обеспечивают генерацию k сначала, если что-то стало нулем
            while (s == 0)
            {
                r = 0;
                while (r == 0)
                {
                    k = 0;
                    while (k == 0)
                    {
                        // Шаг 3 - генерация случайного k, 0 < k < q
                        // Пример из стандарта для теста:
                        // k = BigInteger.Parse("53854137677348463731403841147996619241504003434302020712960838528893196233395");
                        k = generateNumber() % q;
                    }
                    // Шаг 4 - вычисление точки C = kP и определение r = xc (mod q)
                    // Если r = 0, то переход к шагу 3
                    EllipticCurvePoint P = new EllipticCurvePoint(Px, Py);
                    // хитрый метод умножения для хитрого сложения, чтобы сильно уменьшить количество вычислений, чем если накапливать сумму в цикле
                    EllipticCurvePoint C = P.multiply(k);
                    r = C.X % q;
                }
                // Шаг 5 - вычисление s = (r * d + k * e) (mod q)
                // Если s = 0, переход к шагу 3
                s = (r * d + k * e) % q;
            }

            // Шаг 6 - конкатенация r и s (от старших разрядов к младшим слева направо)

            return r.ToByteArray().Concat(s.ToByteArray()).ToArray();
        }
        public bool checkDigitalSignature(byte[] message, byte[] signature)
        {
            return checkDigitalSignature(message, signature, Qx.ToByteArray(), Qy.ToByteArray());
        }

        public bool checkDigitalSignature(byte[] message, byte[] signature, byte[] publicKeyX, byte[] publicKeyY)
        {
            // Шаг 1 - Вычисление r и s из подписи. Если 0 < r < q и 0 < s < q, то все ок, иначе подпись неверна
            BigInteger r, s, e, v, z1, z2;
            
            // Если длина хэш-кода 256 бит, то правая и левая половины подписи (r и s) имеют длину 32 байт, иначе 64
            r = new BigInteger(signature.Take(isHash256() ? 32 : 64).ToArray().Concat(new byte[] { 0 }).ToArray());
            s = new BigInteger(signature.Skip(isHash256() ? 32 : 64).ToArray().Concat(new byte[] { 0 }).ToArray());

            if (r <= 0 || r >= q || s <= 0 || s >= q) return false;

            // Значения из стандарта для проверки
           // s = BigInteger.Parse("574973400270084654178925310019147038455227042649098563933718999175515839552");
           // r = BigInteger.Parse("29700980915817952874371204983938256990422752107994319651632687982059210933395");

            // Шаг 2 - Вычисление хэша сообщения h
            byte[] hash = GOSTHash.createHash(message, isHash256());

            // Шаг 3 - Вычисление e = h (mod q), если e = 0, то e = 1
            e = new BigInteger(hash.Concat(new byte[] { 0 }).ToArray()) % q;

            // Значение из госта для проверки
           //e = BigInteger.Parse("20798893674476452017134061561508270130637142515379653289952617252661468872421");
            if (e == 0) e = 1;

            // Шаг 4 - Вычисление v = e^(-1) (mod q)
            v = ModularArithmetic.inverse_element(e, q);

            // Шаг 5 - Вычисление z1 = s * v (mod q) и z2 = -r * v (mod q)
            z1 = ModularArithmetic.getModulus(s * v, q);
            z2 = ModularArithmetic.getModulus(ModularArithmetic.getModulus(-r, q)* v, q);

            // Шаг 6 - Вычисление точки C = z1 * P + z2 * Q и определение R = xc (mod q)
             EllipticCurvePoint C = new EllipticCurvePoint();
             EllipticCurvePoint P = new EllipticCurvePoint(Px, Py);
             EllipticCurvePoint Q = new EllipticCurvePoint(new BigInteger(publicKeyX.Concat(new byte[] { 0 }).ToArray()), 
                                                           new BigInteger(publicKeyY.Concat(new byte[] { 0 }).ToArray()));
            // Значения из стандарта из конфига для проверки
            // EllipticCurvePoint Q = new EllipticCurvePoint(Qx, Qy);

            C = P.multiply(z1).add(Q.multiply(z2));
            BigInteger R = C.X % q;

            // Шаг 7 - Если R = r, подпись верна, если нет, то неверна
            return R == r;
        }

        public bool ifABCorrect()
        {
            return ModularArithmetic.getModulus(4 * ModularArithmetic.bin_pow(a, 3, p) + 27 * ModularArithmetic.bin_pow(b, 2, p), p) != 0;
        }
        private bool ifJCorrect()
        {
            return J != 0 && J != 1728;
        }
        private BigInteger calculateJ()
        {
            J = ModularArithmetic.getModulus(1728 * ModularArithmetic.divide(4 * ModularArithmetic.bin_pow(a, 3, p), 4 * ModularArithmetic.bin_pow(a, 3, p) + 27 * ModularArithmetic.bin_pow(b, 2, p), p), p);
            return J;
        }
        private BigInteger calculateK()
        {
            if (ifJCorrect()) {
                K = ModularArithmetic.divide(J, 1728 - J, p);
                return K;
            }
            return -1;
        }
        private BigInteger calculateA()
        {
            a = ModularArithmetic.getModulus(3 * K, p);
            return a;
        }
        private BigInteger calculateB()
        {
            b = ModularArithmetic.getModulus(2 * K, p);
            return b;
        }

    }
}
