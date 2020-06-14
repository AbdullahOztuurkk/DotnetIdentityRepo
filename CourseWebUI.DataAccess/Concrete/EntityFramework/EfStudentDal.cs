using System.Collections.Generic;
using System.Linq;
using CourseWebUI.DataAccess.Abstract;
using CourseWebUI.Entities.ComplexTypes;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal:EfEntityRepositoryBase<Student,CourseContext>,IStudentDal
    {
        public List<StudentRoleItem> GetStudentRoles(Student student)
        {
            using (CourseContext db = new CourseContext())
            {
                var result = from ur in db.UserRoles
                    join r in db.Roles
                        on ur.UserId equals r.Id
                    where ur.UserId == student.Id
                    select new StudentRoleItem {RoleName = r.Name};
                return result.ToList();
            }
        }
    }
}
