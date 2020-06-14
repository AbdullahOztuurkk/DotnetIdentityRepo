using System.Collections.Generic;
using CourseWebUI.Entities.ComplexTypes;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Abstract
{
    public interface IStudentDal:IEntityRepository<Student>
    {
        List<StudentRoleItem> GetStudentRoles(Student student);
    }
}
