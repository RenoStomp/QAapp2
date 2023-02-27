using QAapp.CMD.ConsoleHelp;
using QAapp.CMD.Menu;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers.EditHelpers
{
    public class OrderEdit
    {
        public static void UpdateOrder(Order order)
        {
            int index;
            do
            {
                string title = "Choose an option:\n";
                List<string> options = new() { "Change description", "Change price", "Change close date", "Finish editing and save" };
                MenuHelper.ShowOptionsAndChoose(title, options, out index);
                Console.Clear();
                Console.CursorVisible = true;
                switch (index)
                {
                    case 0:
                        Console.WriteLine($"Old description: {order.Description}\n");
                        order.Description = ConsoleHelper.GetStringFromConsole("new description");
                        break;
                    case 1:
                        Console.WriteLine($"Old price: {order.OrderPrice}\n");
                        order.OrderPrice = ConsoleHelper.GetFloatFromConsole("new price");
                        break;
                    case 2:
                        Console.WriteLine($"Old date of adding: {order.CloseDate.Date:dd MMM yyyy}\n");
                        order.CloseDate = ConsoleHelper.GetDateFromConsole("new date of closing");
                        break;          
                    case 3:
                        Console.WriteLine("OK 😊");
                        break;

                }
            } while (index != 3);

            Console.CursorVisible = false;

            MainMenu._orderController.Update(order);
            Console.Clear();
            Console.WriteLine("Order has been updated successfully!");
            MainMenu.Execute();
        }
    }
}
