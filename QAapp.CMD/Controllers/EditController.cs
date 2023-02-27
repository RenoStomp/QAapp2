using QAapp.CMD.Controllers.EditHelpers;
using QAapp.CMD.Menu;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers
{
    public static class EditController<T>
        where T : BaseEntity
    {

        public static void EditEntity()
        {
            if(typeof(T) == typeof(Order))
            {
                List<Order> orders = MainMenu._orderController.ReadAll();
                if(orders.Count < 1)
                {
                    Console.Clear();
                    Console.WriteLine("It is no any orders in database :(\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    MainMenu.Execute();
                    
                }
                List<string> lines = new();
                foreach(var order in orders)
                {
                    lines.Add(order.ToString());
                }
                string title = "Choose which order you want to edit: ";
                MenuHelper.ShowOptionsAndChoose(title, lines, out int index);
                Order orderForEdit = orders[index];

                OrderEdit.UpdateOrder(orderForEdit);
            }
            else
            {
                List<Client> clients = MainMenu._clientController.ReadAll();
                if (clients.Count < 1)
                {
                    Console.Clear();
                    Console.WriteLine("It is no any clients in database :(\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    MainMenu.Execute();

                }
                List<string> lines = new();
                foreach(var client in clients)
                {
                    lines.Add(client.ToString());
                }
                string title = "Choose which client you want to edit: ";
                MenuHelper.ShowOptionsAndChoose(title, lines, out int index);
                Client clientForEdit = clients[index];

                ClientEdit.UpdateClient(clientForEdit);
            }
        }

    }
}