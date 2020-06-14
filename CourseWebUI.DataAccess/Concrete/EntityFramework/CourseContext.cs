using System.Data.Entity;
using CourseWebUI.DataAccess.Concrete.EntityFramework.Mappings;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.DataAccess.Concrete.EntityFramework
{
    public class CourseContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<CourseContext>(null);

            //One to Many relationship

            modelBuilder.Entity<Course>()
                .HasMany(e => e.UserCourses)
                .WithRequired(e => e._Course)
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.UserCourses)
                .WithRequired(e => e._Student)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Configurations.Add(new EfStudentMap());
            modelBuilder.Configurations.Add(new EfCourseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
