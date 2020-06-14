using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Concrete.EntityFramework.Mappings
{
    public class EfUserCourseMap : EntityTypeConfiguration<UserCourse>
    {
        public EfUserCourseMap()
        {
            ToTable("UserCourses", "dbo");
            HasKey(z => z.Id);
        }
    }
}
