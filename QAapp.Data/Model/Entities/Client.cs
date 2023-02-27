using QAapp.Data.Model.Common;

namespace QAapp.Data.Model.Entities
{
    public class Client : Person
    {
        public string PhoneNum { get; set; }
        public uint OrderAmount { get; set; }
        public DateTime DateAdd { get; set; }
        public ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{ID} | {FirstName} | {SecondName} | {OrderAmount} | {DateAdd.Date} | {PhoneNum}";
        }
    }
}
