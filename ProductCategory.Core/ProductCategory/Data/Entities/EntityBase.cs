namespace ProductCategory.Core.ProductCategory.Data.Entities
{
    public class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}