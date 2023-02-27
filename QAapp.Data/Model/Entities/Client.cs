using QAapp.Data.Model.Common;

namespace QAapp.Data.Model.Entities
{
    public class Client : Person
    {
        public string PhoneNum { get; set; }
        public uint OrderAmount { 
            get
            {
                return (uint)Orders.Count;
            }
        }
        public DateTime DateAdd { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Client(string phoneNum, string firstName, string secondName)
        {
            PhoneNum = phoneNum;
            FirstName = firstName;
            SecondName = secondName;
            DateAdd = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{ID} | {FirstName} | {SecondName} | {OrderAmount} | {DateAdd.Date} | {PhoneNum}";
        }
    }
}
