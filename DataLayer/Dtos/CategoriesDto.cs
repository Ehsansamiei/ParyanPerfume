

namespace ParyanPerfume.Dtos
{
    public class CategoriesDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryNickName { get; set; }

        public string CategoryDescription { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? ImageName { get; set; }
    }
}
