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
                List<string> lines = new();
                foreach(var order in orders)
                {
                    lines.Add(order.ToString());
                }
                string title = "Choose which order you want to edit: ";
                MenuHelper.ShowOptionsAndChoose(title, lines, out int index);
                Order orderForEdit = orders[index];

                OrderEdit.UpdateOrder(orderForEdit);

                //Console.WriteLine("Order have been updated successfully!\n" +
                //    "Press any key to return to the Main Menu...");
                //Console.ReadKey(true);
                //MainMenu.Execute();
            }
        }

    }
}