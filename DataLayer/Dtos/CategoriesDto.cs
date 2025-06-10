

namespace ParyanPerfume.Dtos
{
    public class CategoriesDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string CategoryNickName { get; set; } = string.Empty;

        public string CategoryDescription { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; }
        public string? ImageName { get; set; }
    }
}
