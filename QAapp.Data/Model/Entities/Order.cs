using QAapp.Data.Model.Common;

namespace QAapp.Data.Model.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public uint ClientID { get; set; }
        public string Description { get; set; }
        public float OrderPrice { get; set; }
        public DateTime CloseDate { get; set; }
        public Client Client { get; set; }

        public override string ToString()
        {
            return $"{ID} | {Description} | {OrderDate.Date:dd MMM yyyy} | {Client.FullName} | {OrderPrice} | {CloseDate.Date:dd MMM yyyy}";
        }
    }
}
