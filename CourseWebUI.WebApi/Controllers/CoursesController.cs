using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CourseWebUI.Business.Abstract;
using CourseWebUI.Entities.Concrete;
using Microsoft.AspNetCore.Http;
namespace CourseWebUI.WebApi.Controllers
{
    public class CoursesController : ApiController
    {
        private ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("getall")]
        public List<Course> GetAll()
        {
            return _courseService.GetAll();
        }

        [HttpGet]
        [Route("getlistbyname/{id}")]
        public List<Course> GetListByName(string title)
        {
            return _courseService.GetListByCourseName(title);
        }

    }
}
