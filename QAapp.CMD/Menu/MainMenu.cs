using QAapp.CMD.Controllers;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;
using QAapp.Data.Repositories.Implementations;

namespace QAapp.CMD.Menu
{
    public class MainMenu
    {
        private List<string> _options;
        private string _title;

        internal readonly DbRepository<Order> _orderController;
        internal readonly DbRepository<Client> _clientController;

        public MainMenu(DbRepository<Order> orderController, DbRepository<Client> clientController)
        {
            _orderController = orderController;
            _clientController = clientController;
        }
        public void Execute()
        {
            start:
            _options = new() { "Clients", "Orders" };
            _title = "MAIN MENU\n\n" +
                     "Please choose an option:";

            Console.CursorVisible = false;
            Console.Clear();

            MenuHelper.ShowOptionsAndChoose(_title, _options, out int index);

            _options = new() { "Add",  "Edit", "Delete", "Show client's orders", "Return"};
            _title = "";
            switch (index)
            {
                case 0:
                    SecondaryScreen.ShowEntities(_clientController, _options, this);
                    break;
                case 1:
                    SecondaryScreen.ShowEntities(_orderController, _options, this);
                    break;
            }
        }


    }
}
