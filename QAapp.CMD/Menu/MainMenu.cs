namespace QAapp.CMD.Menu
{
    public static class MainMenu
    {
        private static readonly List<string> _lines = new() { "Clients", "Orders" };
        private static readonly string _title = "MAIN MENU\n\n" +
                                                "Please choose an option:";

        public static void Execute()
        {
            Console.CursorVisible = false;
            Console.Clear();
            //int index = 0;
            MenuHelper.ShowOptionsAndChoose(_title, _lines, out int index);
            switch(index)
            {
                case 0:
                    ShowClients();
                    break;
                case 1:
                    ShowOrders();
                    break;
            }
        }

        public static void ShowClients()
        {
            Console.Clear();
            Console.WriteLine("CLIENTS");
        }
        public static void ShowOrders() 
        {
            Console.Clear();
            Console.WriteLine("ORDERS");
        }
    }
}
