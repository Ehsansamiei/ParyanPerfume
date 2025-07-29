using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ParyanPerfumeDbContext _dbContext;
        public CategoryRepository(ParyanPerfumeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.categories;
        }

        public  Category GetCategoryById(int CategoryId)
        {
            return  _dbContext.categories.Find(CategoryId);
        }

        public bool InsertCategory(Category categories)
        {
            try
            {
                _dbContext.categories.Add(categories);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdataCategory(Category categories)
        {
            _dbContext.Entry(categories).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                var categories = GetCategoryById(CategoryId);
                DeleteCategory(categories);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                _dbContext.Entry(category).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> SaveAsync()
        {
            Console.WriteLine("Saving to DB...");
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}