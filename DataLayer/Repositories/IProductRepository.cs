
namespace DataLayer
{


    public interface IProductRepository<T> where T : Product
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Insert(T product);
        Task<bool> Update(T product);
        bool Delete(int id);
        bool Delete(T product);
        Task<int> SaveAsync();
    }

}