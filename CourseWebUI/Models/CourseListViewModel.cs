using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.Models
{
    public class CourseListViewModel 
    {
        public List<Course> Courses { get; set; }
    }
}