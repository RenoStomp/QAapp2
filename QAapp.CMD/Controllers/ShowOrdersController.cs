using QAapp.CMD.Controllers.AddHelpers;
using QAapp.CMD.Menu;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers
{
    public static class ShowOrdersController<T>
        where T : BaseEntity
    {
        public static void ShowOrders(List<T> listOfEntities)
        {
            Client client;
            if (typeof(T) == typeof(Client))
            {
                client = MenuHelper.ShowClientsAndChose(listOfEntities as List<Client>);
            }
            else
            {
                client = MenuHelper.ShowClientsAndChose(MainMenu._clientController.ReadAll());
            }
            if (client == null)
            {
                MainMenu.Execute();
            }

            List<Order> orders = MainMenu._clientController.ReadOrdersByClientId(client.ID);

            Console.Clear();
            string title = $"List of {client.FullName}'s orders:\n" +
                           $"ID | Description | Order's date | Client's name | Price | Closing date\n\n";
            foreach (var order in orders)
            {
                title += order.ToString() + "\n";
            }
            if (orders.Count < 1)
            {
                title += "EMPTY :(((\n";
            }
            List<string> options = new() { "Add", "Edit", "Delete", "Main menu" };
            MenuHelper.ShowOptionsAndChoose(title, options, out int index);

            switch (index)
            {
                case 0:
                    OrderReader.AddOrder(client);
                    Console.WriteLine("Order hase been added successfully!\n" +
                        "Press any key to continue...");
                    Console.ReadKey(true);
                    MainMenu.Execute();
                    break;

                case 1:

                    Environment.Exit(0);
                    break;

                case 2:
                    DeleteController<Order>.DeleteEntity(client);
                    break;
            }
            MainMenu.Execute();


            //TODO: finish EDIT
        }


    }
}