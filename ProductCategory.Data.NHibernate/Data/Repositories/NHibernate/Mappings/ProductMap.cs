using System;
using FluentNHibernate.Mapping;
using ProductCategory.Core.ProductCategory.Data.Entities;

namespace ProductCategory.Data.NHibernate.Data.Repositories.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name).Column("Name");
            References(x => x.ProductCategory).Column("CategoryId");
            Map(x => x.RecordDate).Default(DateTime.Now.ToShortDateString());
            Map(x => x.Image).LazyLoad();
            
        }
    }
}