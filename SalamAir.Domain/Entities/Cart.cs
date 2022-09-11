namespace SalamAir.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual IList<Option> Options { get; set; }
    }
}
