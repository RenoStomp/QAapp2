using QAapp.CMD.Menu;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers
{
    public static class ShowOrdersController<T>
        where T : BaseEntity
    {
        public static void ShowOrders(List<T> listOfEntities, MainMenu menu)
        {
            if (typeof(T) == typeof(Client))
            {
                var client = ShowClientsAndChose(listOfEntities as List<Client>);
                List<Order> orders = menu._clientController.ReadOrdersByClientId(client.ID);
                ShowOrdersController<Order>.ShowOrders(orders, menu);
            }
            else if (typeof(T) == typeof(Order))
            {

            }
        }

        public static Client ShowClientsAndChose(List<Client> clients) 
        {
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

        public static List<Order> FindOrdersOf(Client client)
        {


            return null;
        }
    }
}

//if (typeof(T) == typeof(Order))
//{

//}
//else if (typeof(T) == typeof(Client))
//{

//}