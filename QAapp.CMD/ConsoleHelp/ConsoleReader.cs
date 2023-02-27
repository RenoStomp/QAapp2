using System.Text.RegularExpressions;

namespace QAapp.CMD.ConsoleHelp
{
    public static class ConsoleReader
    {
        public static string ReadFirstName()
        {
            return ConsoleHelper.GetNotEmptyStringFromConsole("your first name");
        }
        public static string ReadLastName()
        {
            return ConsoleHelper.GetNotEmptyStringFromConsole("your last name");
        }
        public static string ReadPhoneNumber()
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
        public static float ReadPrice()
        {
            return ConsoleHelper.GetFloatFromConsole("order's price");
        }



    }
}
