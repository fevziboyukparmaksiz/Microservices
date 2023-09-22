using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeCourse.Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        [DisplayName("Kurs ismi")]
        public string Name { get; set; }
        [DisplayName("Kurs Açıklama")]
        public string Description { get; set; }
        [DisplayName("Kurs Fiyat")]
        public decimal Price { get; set; }
        public string? Photo { get; set; }
        public string? UserId { get; set; }
        [DisplayName("Kurs süre")]
        public FeatureViewModel Feature { get; set; }
        [DisplayName("Kurs kategori")]
        public string CategoryId { get; set; }
        [DisplayName("Kurs Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
