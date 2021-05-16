using System;

namespace FairCryptosystem
{
    static class SnilsValidator
    {

        public static bool SNILSValidate(string snils)
        {
            string workSnils = OnlyDigits(snils);
            bool result = false;

            if (workSnils.Length == 9)
            {
                if (SNILSContolCalc(workSnils) > -1)
                {
                    result = true;
                }
            }
            else if (workSnils.Length == 11)
            {
                int controlSum = SNILSContolCalc(workSnils);
                int strControlSum = int.Parse(workSnils.Substring(9, 2));
                if (controlSum == strControlSum)
                {
                    result = true;
                }
            }
            else
            {
                throw new Exception(string.Format("Incorrect SNILS number. {0} digits! (it can only be 9 or 11 digits!)", workSnils.Length));
            }

            return result;
        }

        public static int SNILSContolCalc(string snils)
        {
            string workSnils = OnlyDigits(snils);

            if (workSnils.Length != 9 && workSnils.Length != 11)
            {
                throw new Exception(string.Format("Incorrect SNILS number. {0} digits! (it can only be 9 or 11 digits!)", workSnils.Length));
            }

            if (workSnils.Length == 11)
            {
                workSnils = workSnils.Substring(0, 9);
            }

            int totalSum = 0;
            for (int i = workSnils.Length - 1, j = 0; i >= 0; i--, j++)
            {
                int digit = int.Parse(workSnils[i].ToString());
                totalSum += digit * (j + 1);
            }

            return SNILSCheckControlSum(totalSum);
        }

        private static int SNILSCheckControlSum(int _controlSum)
        {
            int result;
            if (_controlSum < 100)
            {
                result = _controlSum;
            }
            else if (_controlSum <= 101)
            {
                result = 0;
            }
            else
            {
                int balance = _controlSum % 101;
                result = SNILSCheckControlSum(balance);
            }
            return result;
        }
        public static string OnlyDigits(string source)
        {
            string result = string.Empty;

            foreach (char ch in source)
            {
                if (char.IsDigit(ch))
                {
                    result += ch;
                }
            }

            return result;
        }
    }
}
