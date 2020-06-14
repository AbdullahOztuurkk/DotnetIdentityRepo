using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseWebUI.Entities.Abstract;

namespace CourseWebUI.Entities.Concrete
{
    public class Student:IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Adı Soyadı")]
        public string FullName { get; set; }
        [Display(Name ="Şifre")]
        public string Password { get; set; }
        [Display(Name ="Cinsiyet")]
        public byte Gender { get; set; }
        [Display(Name = "Email Adresi")]
        public string MailAddress { get; set; }
        [Display(Name = "İletişim No")]
        public string PhoneNumber { get; set; }

        public virtual Course course { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
