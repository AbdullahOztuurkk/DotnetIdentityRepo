using System.ComponentModel.DataAnnotations;

namespace CourseWebUI.Core.Mappings.AutoMapper.DataObjects
{
    public class CourseDTO
    {
        public int Id { get; set; }
        [Display(Name = "Kurs Adı")]
        public string CourseName { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
