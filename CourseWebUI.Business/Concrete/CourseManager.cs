using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CourseWebUI.Business.Abstract;
using CourseWebUI.Business.ValidationRules.FluentValidation;
using CourseWebUI.Core.Aspects.Postsharp.Caching;
using CourseWebUI.Core.Aspects.Postsharp.Performance;
using CourseWebUI.Core.Aspects.Postsharp.Security;
using CourseWebUI.Core.Aspects.Postsharp.Validation;
using CourseWebUI.Core.CrossCuttingCorners.Caching.Microsoft;
using CourseWebUI.Core.Utilities.Mappings;
using CourseWebUI.DataAccess.Abstract;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.Business.Concrete
{
    public class CourseManager:ICourseService
    {
        private ICourseDal _courseDal;
        private IMapper _mapper;

        public CourseManager(ICourseDal courseDal, IMapper mapper)
        {
            this._courseDal = courseDal;
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(CourseValidator))]
        public void Add(Course course)
        {
            _courseDal.Add(course);
        }

        public void Delete(Course course)
        {
            _courseDal.Delete(course);
        }

        public void Update(Course course)
        {
            _courseDal.Update(course);
        }

        public Course Get(Expression<Func<Course, bool>> filter)
        {
            return _courseDal.Get(filter);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(1)]
        //[SecuredOperation(Roles = "Admin")]
        public List<Course> GetAll()
        {
            var courses = _courseDal.GetAll().Select(p => new Course
            {
                CourseName = p.CourseName,
                Description = p.Description,
                Id = p.Id
            }).ToList();
            //var courses = _mapper.Map<List<Course>>(_courseDal.GetAll());
            return courses;
        }

        public List<Course> GetListByCourseName(string courseName)
        {
            return _courseDal.GetAll(c => c.CourseName.Contains(courseName));
        }

        public List<Course> GetListByCourseDescription(string description)
        {
            return _courseDal.GetAll(x => x.Description.Contains(description));
        }

        public Course GetListByCourseID(int id)
        {
            return _courseDal.Get(z => z.Id == id);
        }
    }
}
