using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebUI.Core.Mappings.AutoMapper.DataObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Display(Name = "Adı Soyadı")]
        public string FullName { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Cinsiyet")]
        public byte Gender { get; set; }
        [Display(Name = "Email Adresi")]
        public string MailAddress { get; set; }
        [Display(Name = "İletişim No")]
        public string PhoneNumber { get; set; }
    }
}
