using QAapp.Data.Model.Common;

namespace QAapp.Data.Model.Entities
{
    public class Order : BaseEntity
    {
        public DateTime? OrderDate { get; set; }
        public uint ClientID { 
            get
            {
                return Client.ID;
            }
        }
        public string Description { get; set; }
        public float OrderPrice { get; set; }
        public DateTime CloseDate { get; set; }
        public Client Client { get; set; }

        public Order(DateTime closeDate, string description, float orderPrice, Client client) 
        {
            OrderDate = DateTime.Now;
            CloseDate = closeDate;
            Description = description;
            OrderPrice = orderPrice;
            Client = client;

        }
        public override string ToString()
        {
            return $"{ID} | {Description} | {Client.FullName} | {OrderPrice} | {CloseDate.Date}";
        }
    }
}
