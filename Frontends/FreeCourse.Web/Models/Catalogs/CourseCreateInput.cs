using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeCourse.Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        [DisplayName("Kurs ismi")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Kurs Açıklama")]
        [Required]
        public string Description { get; set; }
        [DisplayName("Kurs Fiyat")]
        [Required] 
        public decimal Price { get; set; }
        public string? Picture { get; set; }
        public string? UserId { get; set; }

        [DisplayName("Kurs süre")]
        [Required]
        public FeatureViewModel Feature { get; set; }
        [DisplayName("Kurs kategori")]
        [Required]
        public string CategoryId { get; set; }
    }
}
