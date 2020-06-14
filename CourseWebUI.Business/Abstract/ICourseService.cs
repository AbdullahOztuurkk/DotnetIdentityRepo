using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.Business.Abstract
{
    public interface ICourseService
    {
        void Add(Course course);
        void Delete(Course course);
        void Update(Course course);
        Course Get(Expression<Func<Course, bool>> filter);
        List<Course> GetAll();
        List<Course> GetListByCourseName(string courseName);
        List<Course> GetListByCourseDescription(string description);
        Course GetListByCourseID(int id);

    }
}
