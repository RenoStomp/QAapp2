using QAapp.CMD.Menu;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers
{
    public static class DeleteController<T>
        where T : BaseEntity
    {
        public static void DeleteEntity()
        {
            if (typeof(T) == typeof(Client))
            {
                var client = MenuHelper.ShowClientsAndChose(MainMenu._clientController.ReadAll());
                if (client.OrderAmount > 0)
                {
                    Console.Clear();
                    Console.WriteLine($"!!!!!   {client.FullName} has {client.OrderAmount} orders    !!!!!\n" +
                        $"Are you sure you want to delete {client.FullName}?\n" +
                        $"[Y] - YES    [N] - NO");
                    ConsoleKeyInfo key;
                    do
                    {
                        key = Console.ReadKey(true);
                    } while (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N);

                    if (key.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        Console.WriteLine("Press any key to return to Main Menu...");
                        Console.ReadKey(true);
                        MainMenu.Execute();
                    }
                }
                MainMenu._clientController.Delete(client);
                Console.Clear();
                Console.WriteLine("Client has been deleted successfully!");

            }
            else
            {
                var clientNow = MenuHelper.ShowClientsAndChose(MainMenu._clientController.ReadAll());
                DeleteEntity(clientNow);
            }
            MainMenu.Execute();
        }
        public static void DeleteEntity(Client clientNow)
        {
            List<Order> orders = MainMenu._clientController.ReadOrdersByClientId(clientNow.ID);
            var order = MenuHelper.ShowOrdersAndChose(orders);

            MainMenu._orderController.Delete(order);
            clientNow.OrderAmount--;
            Console.Clear();
            Console.WriteLine("Order has been deleted successfully!");
        }
    }
}