using System.Data.Entity.ModelConfiguration;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Concrete.EntityFramework.Mappings
{
    public class EfStudentMap:EntityTypeConfiguration<Student>
    {
        public EfStudentMap()
        {
            ToTable("Students","dbo");
            HasKey(z => z.Id);

            Property(z => z.FullName).HasColumnName("FullName");
            Property(z => z.Gender).HasColumnName("Gender");
            Property(z => z.MailAddress).HasColumnName("MailAddress");
            Property(z => z.Password).HasColumnName("Password");
            Property(z => z.PhoneNumber).HasColumnName("PhoneNumber");
        }
    }
}
