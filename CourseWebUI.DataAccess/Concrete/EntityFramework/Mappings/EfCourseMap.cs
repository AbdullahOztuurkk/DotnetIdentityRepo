using System.Data.Entity.ModelConfiguration;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Concrete.EntityFramework.Mappings
{
    public class EfCourseMap:EntityTypeConfiguration<Course>
    {
        public EfCourseMap()
        {
            ToTable("Courses", "dbo");
            HasKey(z => z.Id);

            Property(z => z.CourseName).HasColumnName("CourseName");
            Property(z => z.Description).HasColumnName("Description");
        }
    }
}
