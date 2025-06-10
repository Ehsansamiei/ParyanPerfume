

namespace DataLayer
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductById(int PerfumeId);
        bool InsertProduct(Products perfume);
        Task<bool> UpdateProduct(Products perfume);
        bool DeleteProduct(int PerfumeId);
        bool DeleteProduct(Products perfume);

        Task<int> SaveAsync();
    }
}