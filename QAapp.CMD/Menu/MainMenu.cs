using QAapp.Data.Model.Entities;
using QAapp.Data.Repositories.Implementations;
using QAapp.Data.SqlServer;

namespace QAapp.CMD.Menu
{
    public static class MainMenu
    {
        internal static List<string> _options;
        internal static string _title;

        public static AppDbContext ctx = new();

        internal static readonly DbRepository<Order> _orderController = new DbRepository<Order>(ctx);
        internal static readonly DbRepository<Client> _clientController = new DbRepository<Client>(ctx);


        public static void Execute()
        {
            _clientController.ReadAll();

            _options = new() { "Clients", "Orders" };
            _title = "MAIN MENU\n\n" +
                     "Please choose an option:";

            Console.CursorVisible = false;
            Console.Clear();

            MenuHelper.ShowOptionsAndChoose(_title, _options, out int index);

            _options = new() { "Add", "Edit", "Delete", "Show client's orders", "Return" };
            _title = "";
            switch (index)
            {
                case 0:
                    SecondaryScreen.ShowAllEntities(_clientController, _options);
                    break;
                case 1:
                    SecondaryScreen.ShowAllEntities(_orderController, _options);
                    break;
            }
        }


    }
}
