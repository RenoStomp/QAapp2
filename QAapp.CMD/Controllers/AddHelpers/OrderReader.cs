using QAapp.CMD.ConsoleHelp;
using QAapp.CMD.Menu;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers.AddHelpers
{
    public static class OrderReader
    {
        public static void AddOrder()
        {
            Console.Clear();
            string title = "Choose a client to add him an order:";
            List<Client> clients = MainMenu._clientController.ReadAll();

            CheckForClients(clients);

            List<string> lines = new();
            foreach(Client client in clients)
            {
                lines.Add(client.ToString());
            }
            MenuHelper.ShowOptionsAndChoose(title, lines, out int index);

            Client clientForOrder = clients[index];

            AddOrder(clientForOrder);
        }
        public static void AddOrder(Client client)
        {
            Order order = CreateOrder(client);

            client.OrderAmount++;
            MainMenu._orderController.Create(order);
        }
        public static Order CreateOrder(Client client)
        {
            Console.Clear();
            Console.CursorVisible = true;
            DateTime orderDate = DateTime.Now;
            uint clientId = client.ID;
            string description = ConsoleHelper.GetStringFromConsole("description");
            float orderPrice = ConsoleHelper.GetFloatFromConsole("order price");
            DateTime closeDate = ConsoleHelper.GetDateFromConsole("closing date");
            while(closeDate <= orderDate)
            {
                Console.WriteLine($"Please input date AFTER {orderDate.Date:dd MMM yyyy}");
                closeDate = ConsoleHelper.GetDateFromConsole("closing date");
            }

            Console.CursorVisible = false;

            Order order = new Order()
            {
                OrderDate = orderDate,
                ClientID = clientId,
                Description = description,
                OrderPrice = orderPrice,
                CloseDate = closeDate,
            };

            return order;
        }
        public static void CheckForClients(List<Client> clients)
        {
            if(clients.Count < 1)
            {
                Console.WriteLine("It is no clients in database\n" +
                    "Do you wanna add first?\n" +
                    "[Y] - YES    [N] - NO");
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                } while (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N);

                if (key.Key == ConsoleKey.N) MainMenu.Execute();
                else
                {
                    AddController.AddClient();
                    Console.Clear();
                    Console.WriteLine("Client has been created!");
                    AddOrder();
                    Console.WriteLine("Order has been added to client!");
                    MainMenu.Execute();
                }
            }
        }
    }
}
