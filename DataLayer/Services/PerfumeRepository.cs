
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PerfumeRepository : IPerfumeRepository
    {

        private readonly ParyanPerfumeDbContext _dbContext;

        public PerfumeRepository(ParyanPerfumeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Perfume> GetAllPerfumes()
        {
            return _dbContext.perfumes;
        }

        public IEnumerable<Perfume> GetPerfumeListById(int ProductId)
        {
            return _dbContext.perfumes.Where(p => p.Id == ProductId).ToList();
        }

        public Perfume GetPerfumeById(int productId)
        {
            return _dbContext.perfumes.Find(productId);
        }

        public List<Perfume> GetPerfumesByCategoryId(int categoryId)
        {
            return _dbContext.perfumes.Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool InsertPerfume(Perfume perfumes)
        {
            try
            {
                _dbContext.perfumes.Add(perfumes);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> UpdatePerfume(Perfume perfumes)
        {
            _dbContext.Entry(perfumes).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool DeletePerfume(int Id)
        {
            try
            {
                var perfumes = GetPerfumeById(Id);
                DeletePerfume(perfumes);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool DeletePerfume(Perfume perfumes)
        {
            try
            {
                _dbContext.Entry(perfumes).State = EntityState.Deleted;
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