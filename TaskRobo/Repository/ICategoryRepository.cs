using System.Collections.Generic;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public interface ICategoryRepository
    {
        int DeleteCategory(int categoryId);
        IReadOnlyList<Category> GetAllCategories(string email);
        int SaveCategory(Category category);
        Category GetCategoryById(int categoryId);
    }
}