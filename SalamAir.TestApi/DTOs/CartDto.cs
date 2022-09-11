namespace SalamAir.TestApi.DTOs
{
    public class CartDto
    {
        public int ItemId { get; set; }
        public IList<int> OptionIds { get; set; }
    }
}
