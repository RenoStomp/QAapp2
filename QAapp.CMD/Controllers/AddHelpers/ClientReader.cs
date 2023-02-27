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
            string phoneNumber = ConsoleHelper.GetPhoneNumberFromConsole();
            DateTime dateAdd = DateTime.Now;
            uint orderAmount = 0;
            Client client = new Client() 
            { 
                FirstName = firstName,
                SecondName = secondName,
                PhoneNum = phoneNumber,
                DateAdd = dateAdd,
                OrderAmount = orderAmount
            };
            Console.CursorVisible = false;

            return client;
        }
    }
}
