namespace Stores.Entities
{
    public class Employe
    {
        public int EmployeID { get; set; }
        public int HumanID { get; set; }
        public DateTime? DateOfWork { get; set; }
        public string? Position { get; set; }
        public int StoreID { get; set; }

        public virtual Human Human { get; set; }
        public virtual Store Store { get; set; }
    }
}
