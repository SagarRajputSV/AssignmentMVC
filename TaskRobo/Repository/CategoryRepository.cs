using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly TaskDbContext context;
        public CategoryRepository(TaskDbContext _context)
        {
            context = _context;
        }

        // This method should be used to delete category details from database based upon category id
        public int DeleteCategory(int categoryId)
        {
            Category category = GetCategoryById(categoryId);
            context.Categories.Remove(category);
            return 0;
        }

        // This method should be used to get all categories from database based upon user's email
        public IReadOnlyList<Category> GetAllCategories(string email)
        {
            var readonlyList = context.Categories.Select(x => x.EmailId == email);
            var list = readonlyList as List<Category>;
            return list.AsReadOnly();
        }

        // This method should be used to get category details based upon category id
        public Category GetCategoryById(int categoryId)
        {
            Category category = context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            return category;
        }

        // This method should be used to save category details into database
        public int SaveCategory(Category category)
        {
            context.Categories.AddOrUpdate(category);
            return context.SaveChanges();
        }
    }
}