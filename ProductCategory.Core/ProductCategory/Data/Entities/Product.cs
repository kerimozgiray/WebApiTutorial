using System;

namespace ProductCategory.Core.ProductCategory.Data.Entities
{
    public class Product : EntityBase<int>
    {
        public Product()
        {
            RecordDate = DateTime.Now;
        }

        public virtual string Name { get; set; }
        public virtual Category ProductCategory { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual string Image { get; set; }
    }
}