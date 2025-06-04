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

        public IEnumerable<Categories> GetAllCategories()
        {
            return _dbContext.category;
        }

        public  Categories GetCategoryById(int CategoryId)
        {
            return  _dbContext.category.Find(CategoryId);
        }

        public bool InsertCategory(Categories category)
        {
            try
            {
                _dbContext.category.Add(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdataCategory(Categories categories)
        {
            _dbContext.Entry(categories).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                var category = GetCategoryById(CategoryId);
                DeleteCategory(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(Categories category)
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