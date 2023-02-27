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
                     "ID | Name | Surname | Orders count | Date added | Phone number\n\n";
            }
            else if(typeof(T) == typeof(Order))
            {
                title = "Orders list:\n" +
                     "ID | Description | Order's date | Client's name | Price | Closing date\n\n";
            }
            
            foreach (var entity in entities)
            {
                title += entity.ToString() + "\n";
            }

            MenuHelper.ShowOptionsAndChoose(title, options, out int index);

            SecondaryScreenChoise<T>(index, entities);

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
                    EditController<T>.EditEntity();
                    break;

                case 2:
                    DeleteController<T>.DeleteEntity();
                    break;

                case 3:
                    ShowOrdersController<T>.ShowOrders(list);
                    break;

                case 4:
                    MainMenu.Execute();
                    break;
            }
        }



    }
}
