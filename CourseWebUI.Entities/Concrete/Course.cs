using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseWebUI.Entities.Abstract;

namespace CourseWebUI.Entities.Concrete
{
    public class Course:IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Kurs Adı")]
        public string CourseName { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
