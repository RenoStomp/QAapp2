using QAapp.CMD.ConsoleHelp;
using QAapp.CMD.Menu;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers.EditHelpers
{
    public static class ClientEdit
    {
        public static void UpdateClient(Client client)
        {
            int index;
            do
            {
                string title = "Choose an option:\n";
                List<string> options = new() { "Change first name", "Change last name", 
                    "Change phone number", "Finish editing and save" };
                MenuHelper.ShowOptionsAndChoose(title, options, out index);
                Console.Clear();
                Console.CursorVisible = true;
                switch (index)
                {
                    case 0:
                        Console.WriteLine($"Old first name: {client.FirstName}\n");
                        client.FirstName = ConsoleHelper.GetNotEmptyStringFromConsole("new first name");
                        break;
                    case 1:
                        Console.WriteLine($"Old last name: {client.SecondName}\n");
                        client.SecondName = ConsoleHelper.GetNotEmptyStringFromConsole("new second name");
                        break;
                    case 2:
                        Console.WriteLine($"Old phone number: {client.PhoneNum}\n");
                        client.PhoneNum = ConsoleHelper.GetPhoneNumberFromConsole("new phone number");
                        break;
                    case 3:
                        Console.WriteLine("OK 😊");
                        break;

                }
            } while (index != 3);

            Console.CursorVisible = false;

            MainMenu._clientController.Update(client);
            Console.Clear();
            Console.WriteLine("Client has been updated successfully!\n" +
                "Press any button to return to the Main Menu");
            Console.ReadKey(true);
            MainMenu.Execute();
        }
    }
}
