using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;

namespace SalamAir.Data.Repositories
{
    public class ItemRepository : DefaultRepository<Item>, IItemRepository
    {
        public ItemRepository(SalamAirContext context) : base(context)
        {
        }
    }
}
