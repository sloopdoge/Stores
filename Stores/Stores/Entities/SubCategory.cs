namespace Stores.Entities
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string SubCategoryTitle { get; set; }

        public virtual Category Category { get; set; }
    }
}
