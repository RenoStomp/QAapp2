namespace QAapp.Data.Model.Common
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {SecondName}";
            }
        }
    }
}
