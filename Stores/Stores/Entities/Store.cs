namespace Stores.Entities
{
    public class Store
    {
        public int StoreID { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PostCode { get; set; }
        public int Owner { get; set; }
    }
}
