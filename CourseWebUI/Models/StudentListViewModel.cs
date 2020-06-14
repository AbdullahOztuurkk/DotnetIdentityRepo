using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.Models
{
    public class StudentListViewModel
    {
        public List<Student> Students { get; set; }
    }
}