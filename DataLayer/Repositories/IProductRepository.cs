

namespace DataLayer
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Products> GetAllProducts();
        IEnumerable<Products> GetProductListById(int ProductId);
        List<Products> GetProductsByCategoryId(int categoryId);

        Products GetProductById(int ProductId);
        bool InsertProduct(Products product);
        Task<bool> UpdateProduct(Products product);
        bool DeleteProduct(int ProductId);
        bool DeleteProduct(Products product);

        Task<int> SaveAsync();
    }
}