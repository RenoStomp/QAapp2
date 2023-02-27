using QAapp.CMD.ConsoleHelp;
using QAapp.Data.Model.Entities;

namespace QAapp.CMD.Controllers.AddHelpers
{
    public static class ClientReader
    {
        public static Client CreateClient()
        {
            Console.Clear();
            Console.CursorVisible = true;
            string firstName = ConsoleHelper.GetNotEmptyStringFromConsole("first name");
            string secondName = ConsoleHelper.GetNotEmptyStringFromConsole("second name");
            string phoneNumber = ConsoleHelper.GetPhoneNumberFromConsole("phone number");
            DateTime dateAdd = DateTime.Now;
            Client client = new Client()
            {
                FirstName = firstName,
                SecondName = secondName,
                PhoneNum = phoneNumber,
                DateAdd = dateAdd,
            };
            Console.CursorVisible = false;

            return client;
        }
    }
}
