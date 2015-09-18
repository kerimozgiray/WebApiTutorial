using System;

namespace ProductCategoryTutorial.RestApi.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public DateTime RecordDate { get; set; }
    }
}