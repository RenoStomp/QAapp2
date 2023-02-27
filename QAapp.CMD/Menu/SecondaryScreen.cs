using QAapp.CMD.Controllers;
using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;
using QAapp.Data.Repositories.Implementations;

namespace QAapp.CMD.Menu
{
    public static class SecondaryScreen
    {
        public static void ShowAllEntities<T>(DbRepository<T> controller, List<string> options)
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

            SecondaryScreenChoise<T>(index, entities);

            Console.ReadKey();
        }
        public static void SecondaryScreenChoise<T>(int index, List<T> list)
            where T : BaseEntity
        {
            switch (index)
            {
                case 0:
                    AddController.AddEntity();
                    break;

                case 1:

                    Environment.Exit(0);
                    break;

                case 2:

                    Environment.Exit(0);
                    break;

                case 3:
                    ShowOrdersController<T>.ShowOrders(list);
                    break;

                case 4:
                    MainMenu.Execute();
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
