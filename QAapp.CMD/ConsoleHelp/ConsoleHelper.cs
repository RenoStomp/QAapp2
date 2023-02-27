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
            float value = 0;
            while(!float.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Incorrect input. Only fractional numbers allowed.\n " +
                            "Try again and don't forget to use point or comma (only one of those signs): ");
            }
            return value;
        }


    }
}
