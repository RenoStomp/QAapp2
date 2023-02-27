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
                var entity = MenuHelper.ShowClientsAndChose(MainMenu._clientController.ReadAll());
            }
            else
            {
                var entity = MenuHelper.ShowClientsAndChose(new List<Client>(MainMenu._clientController.ReadAll()));
            }
            //if (entity == null)
            //{
            //    MainMenu.Execute();
            //}
        }
    }
}

//if (typeof(T) == typeof(Order))
//{

//}
//else if (typeof(T) == typeof(Client))
//{

//}