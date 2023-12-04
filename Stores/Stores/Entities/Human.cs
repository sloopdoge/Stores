namespace Stores.Entities
{
    public class Human
    {
        public int HumanID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
    }
}
