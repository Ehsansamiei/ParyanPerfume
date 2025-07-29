

namespace DataLayer
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Perfume> GetAllPerfumes();
        IEnumerable<Perfume> GetPerfumeListById(int ProductId);
        List<Perfume> GetPerfumesByCategoryId(int categoryId);

        Perfume GetPerfumeById(int ProductId);
        bool InsertPerfume(Perfume product);
        Task<bool> UpdatePerfume(Perfume product);
        bool DeletePerfume(int ProductId);
        bool DeletePerfume(Perfume product);

        Task<int> SaveAsync();
    }
}