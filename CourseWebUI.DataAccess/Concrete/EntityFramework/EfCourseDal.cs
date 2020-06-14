using CourseWebUI.DataAccess.Abstract;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal:EfEntityRepositoryBase<Course,CourseContext>,ICourseDal
    {
    }
}
