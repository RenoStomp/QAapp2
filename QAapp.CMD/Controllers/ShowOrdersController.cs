using Microsoft.Extensions.Options;
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
                client = ShowClientsAndChose(listOfEntities as List<Client>);
            }
            else
            {
                client = ShowClientsAndChose(new List<Client>(MainMenu._clientController.ReadAll()));
            }
            if(client == null) 
            {
                MainMenu.Execute();
            }

            List<Order> orders = MainMenu._clientController.ReadOrdersByClientId(client.ID);
            Console.Clear();
            Console.WriteLine($"List of {client.FullName}'s orders:");
            foreach(var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
            //TODO: finish editing orders at clients orders list
            Console.ReadKey();

        }

        public static Client ShowClientsAndChose(List<Client> clients) 
        {
            if(clients.Count == 0) 
            {
                Console.Clear();
                Console.WriteLine("It is no any client in database...\n" +
                    "Press any key...");
                Console.ReadKey(true);
                MainMenu.Execute();
                return null;
            }
            List<string> names = new();
            foreach (var client in clients)
            {
                names.Add(client.ToString());
            }

            string title = "Choose a client:\n" +
                     "ID | Name | Surname | Orders count | Date added | Phone number\n";
            MenuHelper.ShowOptionsAndChoose(title, names, out int index);
            return clients[index];
        }
    }
}