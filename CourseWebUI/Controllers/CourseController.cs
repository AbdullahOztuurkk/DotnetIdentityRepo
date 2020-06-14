using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseWebUI.Business.Abstract;
using CourseWebUI.Entities.Concrete;
using CourseWebUI.Models;

namespace CourseWebUI.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public ActionResult Index()
        {
            var model = new CourseListViewModel
            {
                Courses = _courseService.GetAll()
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View("CourseForm");
        }
        [HttpPost]
        public ActionResult Add(Course course)
        {
            if (course.Id == 0) //Insert Operation
            {
                _courseService.Add(course);
            }
            else//Update Operation
            {
                _courseService.Update(course);
            }

            return RedirectToAction("Index");
        }
    }
}