

namespace DataLayer
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int CategoryId);
        bool InsertCategory(Category category);
        Task<bool> UpdataCategory(Category categories);
        bool DeleteCategory(int CategoryId);
        bool DeleteCategory(Category category);

        Task<int> SaveAsync();
    }
}