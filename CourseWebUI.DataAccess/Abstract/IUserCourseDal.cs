using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWebUI.DataAccess.Concrete.EntityFramework;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Abstract
{
    public interface IUserCourseDal:IEntityRepository<UserCourse>
    {
    }
}
