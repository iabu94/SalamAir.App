using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;

namespace SalamAir.Data.Repositories
{
    public class CartRepository : DefaultRepository<Cart>, ICartRepository
    {
        public CartRepository(SalamAirContext context) : base(context)
        {
        }
    }
}
