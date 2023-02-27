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
            if (typeof(T) == typeof(Client))
            {
                ShowClientsAndChose(listOfEntities as List<Client>);

            }
            else if (typeof(T) == typeof(Order))
            {

            }
        }

        public static void ShowClientsAndChose(List<Client> clients) 
        {
            List<string> names = new();
            foreach (var client in clients)
            {
                names.Add(client.ToString());
            }
            string title = "Choose a client:\n" +
                     "ID | Name | Surname | Orders count | Date added | Phone number\n";
            MenuHelper.ShowOptionsAndChoose(title, names, out int index);

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