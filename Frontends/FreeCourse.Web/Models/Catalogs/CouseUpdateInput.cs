﻿using System.ComponentModel;
using Microsoft.Build.Framework;

namespace FreeCourse.Web.Models.Catalogs
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Kurs Açıklama")]
        [Required]
        public string Description { get; set; }
        [DisplayName("Kurs Fiyat")]
        [Required]
        public decimal Price { get; set; }
        public string? Photo { get; set; }
        public string? UserId { get; set; }

        [DisplayName("Kurs süre")]
        [Required]
        public FeatureViewModel Feature { get; set; }
        [DisplayName("Kurs kategori")]
        [Required]
        public string CategoryId { get; set; }
        [DisplayName("Kurs Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
