
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ProductRepository : IProductRepository
    {

        private readonly ParyanPerfumeDbContext _dbContext;

        public ProductRepository(ParyanPerfumeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _dbContext.product;
        }

        public Products GetProductById(int productId)
        {
            return _dbContext.product.Find(productId);
        }

        public bool InsertProduct(Products product)
        {
            try
            {
                _dbContext.product.Add(product);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> UpdateProduct(Products product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                var product = GetProductById(productId);
                DeleteProduct(product);
                return true;
                
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProduct(Products product)
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

        public void Dispose()
        {
            _dbContext.Dispose();
        }


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}