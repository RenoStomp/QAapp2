namespace QAapp.CMD.Menu
{
    public class MenuHelper
    {

        public static void ShowOptionsAndChoose(string title, List<string> lines, out int index)
        {
            index = 0;
            ShowOptions(title, lines, index);
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index + 1 < lines.Count)
                        {
                            index++;
                        }
                        ShowOptions(title, lines, index);
                        break;
                    case ConsoleKey.UpArrow:
                        if (index - 1 >= 0)
                        {
                            index--;
                        }
                        ShowOptions(title, lines, index);
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

            if(keyInfo.Key == ConsoleKey.Escape) 
            {
                Environment.Exit(0);
            }

        }

        public static void ShowOptions(string title, List<string> lines, int index)
        {
            Console.Clear();
            Console.WriteLine($"{title}\n");
            for (int i = 0; i < lines.Count; i++)
            {
                if (index.Equals(i))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" >> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(lines[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("[UP] Up  [Down] Down  [Enter] Choose\n" +
                              "[ESC] Close app");
        }


    }
}
