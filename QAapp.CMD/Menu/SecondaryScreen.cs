using QAapp.CMD.Controllers;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;
using QAapp.Data.Repositories.Implementations;

namespace QAapp.CMD.Menu
{
    public static class SecondaryScreen
    {
        public static void ShowEntities<T>(DbRepository<T> controller, List<string> options, MainMenu menu)
            where T : BaseEntity
        {
            List<T> entities = controller.ReadAll();

            Console.Clear();

            string title = "";
            if(typeof(T) == typeof(Client))
            {
                title = "Clients list:\n" +
                     "ID | Name | Surname | Orders count | Date added | Phone number\n";
            }
            else if(typeof(T) == typeof(Order))
            {
                title = "Orders list:\n" +
                     "ID | Description | Client's name | Price | Closing date";
            }
            MenuHelper.ShowOptionsAndChoose(title, options, out int index);

            SecondaryScreenChoise<T>(index, entities, menu);

            Console.ReadKey();
        }
        public static void SecondaryScreenChoise<T>(int index, List<T> list, MainMenu menu)
            where T : BaseEntity
        {
            switch (index)
            {
                case 0:

                    break;

                case 1:

                    break;

                case 2:

                    break;

                case 3:
                    ShowOrdersController<T>.ShowOrders(list, menu);
                    break;

                case 4:
                    menu.Execute();
                    break;
            }
        }

        //public static void ShowClients(DbRepository<Client> _clientController, List<string> options, MainMenu menu)
        //{

        //    List<Client> clients = _clientController.ReadAll();

        //    Console.Clear();

        //    string title = "Clients list:\n" +
        //             "ID | Name | Surname | Orders count | Date added | Phone number\n";
        //    foreach (Client client in clients)
        //    {
        //        title += client.ToString() + "\n";
        //    }



        //    MenuHelper.ShowOptionsAndChoose(title, options, out int index);

        //    SecondaryScreenChoise<Client>(index, clients, menu);


        //    Console.ReadKey();

        //}
        //public static void ShowOrders(DbRepository<Order> _orderController, List<string> options, MainMenu menu)
        //{

        //    List<Order> orders = _orderController.ReadAll();

        //    Console.Clear();

        //    string title = "Orders list:\n" +
        //             "ID | Description | Client's name | Price | Closing date";
        //    foreach (Order order in orders)
        //    {
        //        title += order.ToString() + "\n";
        //    }

        //    MenuHelper.ShowOptionsAndChoose(title, options, out int index);

        //    SecondaryScreenChoise<Order>(index, orders, menu);


        //    Console.ReadKey();
        //}


    }
}
