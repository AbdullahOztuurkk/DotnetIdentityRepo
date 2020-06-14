using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWebUI.DataAccess.Abstract;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Concrete.EntityFramework
{
    public class EfUserCourseDal:EfEntityRepositoryBase<UserCourse,CourseContext>,IUserCourseDal
    {
    }
}
