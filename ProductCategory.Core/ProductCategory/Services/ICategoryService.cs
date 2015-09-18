using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCategory.Core.ProductCategory.Data.Entities;

namespace ProductCategory.Core.ProductCategory.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();

        Category GetCategoryById(int categoryId);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int categoryId);
    }
}
