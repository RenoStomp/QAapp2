using QAapp.Data.Model.Entities;
using QAapp.Data.Repositories.Implementations;

namespace QAapp.CMD.Menu
{
    public class MainMenu
    {
        private List<string> _options;
        private string _title;

        private readonly DbRepository<Order> _orderController;
        private readonly DbRepository<Client> _clientController;

        public MainMenu(DbRepository<Order> orderController, DbRepository<Client> clientController)
        {
            _orderController = orderController;
            _clientController = clientController;
        }
        public void Execute()
        {
            _options = new() { "Clients", "Orders" };
            _title = "MAIN MENU\n\n" +
                     "Please choose an option:";

            Console.CursorVisible = false;
            Console.Clear();

            MenuHelper.ShowOptionsAndChoose(_title, _options, out int index);
            switch (index)
            {
                case 0:
                    ShowClients();
                    break;
                case 1:
                    ShowOrders();
                    break;
            }
        }

        public void ShowClients()
        {
            //_lines.Clear();
            //_title = "";
            //for()

            Console.Clear();

            Console.WriteLine("Clients list:\n");

        }
        public void ShowOrders()
        {
            Console.Clear();

            Console.WriteLine("ORDERS");
        }
    }
}
