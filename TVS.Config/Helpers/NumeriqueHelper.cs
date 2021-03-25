using System.Threading;
using System;

namespace TVS.Config.Helpers
{
    public static class NumeriqueHelper
    {
        public static decimal ConvertToDecimal(string valueStr)
        {
            try
            {
                if (string.IsNullOrEmpty(valueStr)) return 0;
                var culture = Thread.CurrentThread.CurrentCulture;
                var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
                var value = valueStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return decimal.TryParse(value, out result) ? result : 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int ConvertToInt(string valueStr)
        {
            if (string.IsNullOrEmpty(valueStr)) return 0;
            int result;
            return int.TryParse(valueStr, out result) ? result : 0;
        }

        public static bool ValiderMatricule(string matricule)
        {
            if (matricule == null)
                return false;

            if (matricule.Length != 13)
            {
                if (13 - matricule.Length > 3)
                    return false;

                for (int i = matricule.Length; i < 13; i++)
                    matricule = matricule.Insert(0, "0");
            }

            if (!char.IsLetter(matricule[7]) ||
                !char.IsLetter(matricule[8]) ||
                !char.IsLetter(matricule[9]))
                return false;

            int cleN = 0;
            string num = matricule.Substring(0, 7);

            for (int i = 7; i > 0; i--)
            {
                if (!char.IsDigit(num[7 - i]))
                    return false;

                cleN += i*int.Parse(num[7 - i].ToString());
            }

            char cleX = ' ';
            cleN %= 23;

            if (cleN < 8)
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A'));
            else if (cleN < 13)
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A') + 1);
            else if (cleN < 18)
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A') + 2);
            else
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A') + 3);

            if (cleX != matricule[7])
                return false;

            if (matricule[8] != 'A' && matricule[8] != 'B' && matricule[8] != 'N' && matricule[8] != 'P' &&
                matricule[8] != 'D')
                return false;

            if (matricule[9] != 'M' && matricule[9] != 'C' && matricule[9] != 'P' && matricule[9] != 'N' &&
                matricule[9] != 'E')
                return false;
            var etb = matricule.Remove(0, 10);
            if (etb != "000" && matricule[9] != 'E')
                return false;
            return true;
        }
    
        public static string Left(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                    ? value
                    : value.Substring(0, maxLength)
                    );
        }
        
        public static string GetMatriculeCleRib(string identite)
        {
            double num = 0;
            if (!double.TryParse(identite, out num))
            {
                return string.Empty;
            }
            //var x = string.Concat(identite, "00000000000000000000");

           // string str = Left(x, 20);

            string str = identite.PadRight(20, '0');
            var numLeft = str.Substring(0, 10);
            var numRight = str.Substring(10, 10);
            double num1 = 0;
            double.TryParse(numLeft, out num1);
            double num2 = 0;
            double.TryParse(numRight, out num2);
            double num3 = num1%97;
            double num4 = num3*10000000000 + num2%97;
            num4 = 97 - num4%97;
            return num4.ToString("00");
        }

        public static string GetMatriculeCle(string matricule)
        {
            if (matricule == null)
                return string.Empty;

            if (matricule.Trim() == string.Empty)
                return string.Empty;

            int mat = 0;
            if (!int.TryParse(matricule, out mat))
                return string.Empty;
            else if (mat == 0)
                return string.Empty;

            if (matricule.Length != 7)
            {
                for (int i = matricule.Length; i < 7; i++)
                    matricule = matricule.Insert(0, "0");
            }

            int cleN = 0;

            for (int i = 7; i > 0; i--)
            {
                if (!char.IsDigit(matricule[7 - i]))
                    return string.Empty;

                cleN += i*int.Parse(matricule[7 - i].ToString());
            }

            char cleX = ' ';
            cleN %= 23;

            if (cleN < 8)
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A'));
            else if (cleN < 13)
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A') + 1);
            else if (cleN < 18)
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A') + 2);
            else
                cleX = Convert.ToChar(cleN + Convert.ToInt32('A') + 3);

            return cleX.ToString();
        }
    }
}