using System;

namespace NumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Обчислення арифметичних операцій в різних системах числення");
            Console.WriteLine("");

Console.Write("Введіть перше число: ");
            string num1 = Console.ReadLine();

            Console.Write("Введіть операцію (+, -, *, /): ");
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.Write("Введіть друге число: ");
            string num2 = Console.ReadLine();

            Console.Write("Виберіть систему числення (2 для двійкової, 8 для вісімкової, 10 для десяткової, 16 для шістдесяткової): ");
            int baseValue = int.Parse(Console.ReadLine());
            //Переводимо числа в десяткову систему числення
            double decimalNum1 = ConvertToDecimal(num1, baseValue);
            double decimalNum2 = ConvertToDecimal(num2, baseValue);

            double result = 0;
            switch (operation)
            {
                case '+':
                    result = decimalNum1 + decimalNum2;
                    break;
                case '-':
                    result = decimalNum1 - decimalNum2;
                    break;
                case '*':
                    result = decimalNum1 * decimalNum2;
                    break;
                case '/':
                    if (decimalNum2 != 0)
                    {
                        result = decimalNum1 / decimalNum2;
                    }
                    else
                    {
                        Console.WriteLine("Помилка: ділення на нуль!");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Невірна операція.");
                    return;
            }
            string resultInBase = ConvertFromDecimal(result, baseValue);

            Console.WriteLine($"Результат: {resultInBase}");
        }
        static double ConvertToDecimal(string number, int baseValue)
        {
            if (baseValue == 10)
                return double.Parse(number);

            char[] digits = number.ToCharArray();
            Array.Reverse(digits);

            double decimalValue = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                int digitValue = char.IsDigit(digits[i]) ? digits[i] - '0' : char.ToUpper(digits[i]) - 'A' + 10;
                decimalValue += digitValue * Math.Pow(baseValue, i);
            }

            return decimalValue;
        }
        static string ConvertFromDecimal(double number, int baseValue)
        {
            if (baseValue == 10)
                return number.ToString();

            string result = "";

            while (number > 0)
            {
                double remainder = number % baseValue;
                char digit = (char)(remainder < 10 ? '0' + remainder : 'A' + (int)(remainder - 10));
                result = digit + result;
                number = Math.Floor(number / baseValue);
            }

            return result;
        }
    }
}
