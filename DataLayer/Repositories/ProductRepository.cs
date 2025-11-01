using Microsoft.EntityFrameworkCore;

namespace DataLayer
{

    public class ProductRepository<T> : IProductRepository<T> where T : Product
    {
        private readonly ParyanPerfumeDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public ProductRepository(ParyanPerfumeDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);

        public bool Insert(T product)
        {
            try
            {
                _dbSet.Add(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(T product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            return Delete(product);
        }

        public bool Delete(T product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    }

}