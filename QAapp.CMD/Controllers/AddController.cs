using QAapp.CMD.Menu;
using QAapp.Data.Model.Common;

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

                    break;
                case 1:

                    break;
            }
        }

        public static void AddClient()
        {

        }
    }
}

//if (typeof(T) == typeof(Order))
//{

//}
//else if (typeof(T) == typeof(Client))
//{

//}