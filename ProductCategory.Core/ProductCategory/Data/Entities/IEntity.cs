namespace ProductCategory.Core.ProductCategory.Data.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}