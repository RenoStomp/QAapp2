using QAapp.CMD.Menu.Blank;

namespace QAapp.CMD.Menu
{
    public static class MenuHelper
    {

        public static void ShowOptionsAndChoose(string title, List<string> options, out int index)
        {
            index = 0;
            ShowOptions(title, options, index);
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index + 1 < options.Count)
                        {
                            index++;
                        }
                        ShowOptions(title, options, index);
                        break;
                    case ConsoleKey.UpArrow:
                        if (index - 1 >= 0)
                        {
                            index--;
                        }
                        ShowOptions(title, options, index);
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

            if(keyInfo.Key == ConsoleKey.Escape) 
            {
                LastMessage.TheEnd();
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
                              "[Esc] Close app");
        }


    }
}
