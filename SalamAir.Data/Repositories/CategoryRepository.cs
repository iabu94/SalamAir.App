using Microsoft.EntityFrameworkCore;
using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;

namespace SalamAir.Data.Repositories
{
    public class CategoryRepository : DefaultRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SalamAirContext context) : base(context)
        {
        }
    }
}
