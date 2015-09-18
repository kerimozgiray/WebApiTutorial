using FluentNHibernate.Mapping;
using ProductCategory.Core.ProductCategory.Data.Entities;

namespace ProductCategory.Data.NHibernate.Data.Repositories.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name).Column("Name");
            //HasMany(x => x.Products)
            //    .Inverse()
            //    .KeyColumns.Add("CategoryId", mapping => mapping.Name("CategoryId"));
        }
    }
}