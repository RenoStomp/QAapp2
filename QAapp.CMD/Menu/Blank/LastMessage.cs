namespace QAapp.CMD.Menu.Blank
{
    /// <summary>
    /// Just last line ... nothing special ... tut ne na chto smotret
    /// </summary>
    internal static class LastMessage
    {
        internal static void TheEnd()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            string endLine = Decrypting.decryptedText;
            int width = Console.WindowWidth / 2 - endLine.Length / 2;
            int height = Console.WindowHeight / 2 - 5;
            Console.SetCursorPosition(width, height);

            Console.WriteLine(endLine);
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }
    }
}
