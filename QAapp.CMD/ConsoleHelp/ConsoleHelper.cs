using System.Text.RegularExpressions;

namespace QAapp.CMD.ConsoleHelp
{
    public static class ConsoleHelper
    {
        public static string GetStringFromConsole(string fieldName)
        {
            Console.Write($"Please enter {fieldName}: ");
            string value = Console.ReadLine().Trim();

            return value;
        }
        public static string GetNotEmptyStringFromConsole(string fieldName)
        {
            string value = GetStringFromConsole(fieldName);
            while (value.Length < 1)
            {
                Console.Write("Field cannot be empty. Try again: ");
                value = Console.ReadLine().Trim();
            }

            return value;
        }
        public static int GetNumFromConsole(string fieldName)
        {
            Console.Write($"Input {fieldName}: ");
            int value;
            while (!Int32.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Incorrect input. Only numbers allowed. Try again: ");
            }

            return value;
        }
        public static int GetPositiveIntFromConsole(string fieldName)
        {
            int value = GetNumFromConsole(fieldName);
            while (value < 0)
            {
                Console.WriteLine("Number cannot be lower then 0");
                value = GetNumFromConsole(fieldName);
            }

            return value;
        }
        public static float GetFloatFromConsole(string fieldName)
        {
            Console.Write($"Input {fieldName} using point or comma: ");
            float value;
            while (!float.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Incorrect input. Only fractional numbers allowed.\n " +
                            "Try again and don't forget to use point or comma (only one of those signs): ");
            }
            return value;
        }
        public static string GetPhoneNumberFromConsole()
        {
            Console.Write("Input your phone number: +996");
            int phoneNum;
            while (!int.TryParse(Console.ReadLine(), out phoneNum) || phoneNum.ToString().Length != 9)
            {
                Console.Write("Incorrect input, try again: +996");
            }
            string phoneNumber = phoneNum.ToString();

            int MobileOperatorNumbers = Convert.ToInt32(phoneNumber.Substring(0, 3));
            string correctNumbers = Regex.Replace(phoneNumber.Substring(3), ".{2}", "$0-");
            correctNumbers = correctNumbers.Substring(0, correctNumbers.Length - 1);

            return $"+996({MobileOperatorNumbers}){correctNumbers}";
        }
        public static DateTime GetDateFromConsole(string fieldName)
        {
            Console.WriteLine($"Input {fieldName}: ");
            int year = GetPositiveIntFromConsole("YEAR");

            int month = GetPositiveIntFromConsole("MONTH number");

            int day = GetPositiveIntFromConsole("DAY");

            string fullDate = $"{year}/{month}/{day}";

            DateTime date;

            while (!DateTime.TryParse(fullDate, out date))
            {
                Console.WriteLine("Impossible date. Try again");
                date = GetDateFromConsole(fieldName);
                fullDate = date.ToString();
            }
            return date;
        }

    }
}
