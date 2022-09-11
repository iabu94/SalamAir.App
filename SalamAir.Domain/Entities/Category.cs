﻿namespace SalamAir.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        public virtual IList<SubCategory> SubCategories { get; set; }
    }
}
