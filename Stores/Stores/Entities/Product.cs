namespace Stores.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string ProductTitle { get; set; }
        public long TaxGroup { get; set; }
        public byte IsMature { get; set; }
        public byte ExciseNeeded { get; set; }
    }
}
