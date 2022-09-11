namespace SalamAir.Domain.Entities
{
    public class Option : BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<Cart> Carts { get; set; }
    }
}
