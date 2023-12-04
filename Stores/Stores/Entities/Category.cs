namespace Stores.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
