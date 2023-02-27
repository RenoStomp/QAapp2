using QAapp.CMD.Controllers.AddHelpers;
using QAapp.CMD.Menu;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers
{
    public static class AddController
    {
        public static void AddEntity()
        {
            string title = "Choose what you wanna add:";
            List<string> options = new() { "Client", "Order" };
            MenuHelper.ShowOptionsAndChoose(title, options, out int index);
            switch (index)
            {
                case 0:
                    AddClient();
                    break;
                case 1:
                    AddOrder();
                    break;
            }
        }

        public static void AddClient()
        {
            Client client = ClientReader.CreateClient();
            MainMenu._clientController.Create(client);
        }
        public static void AddOrder()
        {
            Order order = OrderReader.CreateOrder();
            MainMenu._orderController.Create(order);
        }
    }
}

//if (typeof(T) == typeof(Order))
//{

//}
//else if (typeof(T) == typeof(Client))
//{

//}