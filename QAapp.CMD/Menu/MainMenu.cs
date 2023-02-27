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

            _options = new() { "Add",  "Edit", "Delete", "Show client's orders", "Return"};
            _title = "";
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

            List<Client> clients = _clientController.ReadAll();

            Console.Clear();

            _title = "Clients list:\n" +
                     "ID | Name | Surname | Orders count | Date added | Phone number\n";
            foreach (Client client in clients)
            {
                _title += client.ToString() + "\n";
            }
            
            

            MenuHelper.ShowOptionsAndChoose(_title, _options, out int index);



            Console.ReadKey();

        }
        public void ShowOrders()
        {

            List<Order> orders = _orderController.ReadAll();

            Console.Clear();

            _title = "Orders list:\n" +
                     "ID | Description | Client's name | Price | Closing date";
            foreach (Order order in orders)
            {
                _title += order.ToString() + "\n";
            }

            MenuHelper.ShowOptionsAndChoose(_title, _options, out int index);




            Console.ReadKey();
        }

        //public void
    }
}
