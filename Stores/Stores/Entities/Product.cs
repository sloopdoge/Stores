namespace Stores.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int? CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public string ProductTitle { get; set; }
        public long TaxGroup { get; set; }
        public bool IsMature { get; set; }
        public bool ExciseNeeded { get; set; }

        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
