using FreeCourse.Web.Models.Catalogs;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CourseViewModel>> GetAllCourseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseViewModel>> GetAllCourseByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CourseViewModel> GetByCourseIdAsync(string courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCourseAsync(CourseCreateInput courseCreateInput)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCourseAsync(CouseUpdateInput courseUpdateInput)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCourseAsync()
        {
            throw new NotImplementedException();
        }
    }
}
