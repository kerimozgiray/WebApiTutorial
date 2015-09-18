using System.Collections;
using System.Collections.Generic;

namespace ProductCategory.Core.ProductCategory.Data.Entities
{
    public class Category : EntityBase<int>
    {
        public virtual string Name { get; set; }
    }
}