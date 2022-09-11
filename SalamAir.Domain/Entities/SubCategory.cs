namespace SalamAir.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IList<Item> Items { get; set; }
    }
}
