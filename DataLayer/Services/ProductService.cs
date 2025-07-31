namespace DataLayer
{
    public class ProductService<T> where T : Product
    {
        private readonly IProductRepository<T> _repository;

        public ProductService(IProductRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAllProducts() => _repository.GetAll();

        public T GetProductById(int id) => _repository.GetById(id);

        public bool AddProduct(T product) => _repository.Insert(product);

        public Task<bool> UpdateProduct(T product) => _repository.Update(product);

        public bool DeleteProduct(int id) => _repository.Delete(id);

        public Task<int> SaveAsync() => _repository.SaveAsync();
    }

}