

namespace DataLayer
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategoryById(int CategoryId);
        bool InsertCategory(Categories category);
        Task<bool> UpdataCategory(Categories categories);
        bool DeleteCategory(int CategoryId);
        bool DeleteCategory(Categories category);

        Task<int> SaveAsync();
    }
}