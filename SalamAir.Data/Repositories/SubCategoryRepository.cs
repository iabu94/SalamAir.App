using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;

namespace SalamAir.Data.Repositories
{
    public class SubCategoryRepository : DefaultRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(SalamAirContext context) : base(context)
        {
        }
    }
}
