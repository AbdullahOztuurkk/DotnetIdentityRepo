using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseWebUI.Core.Mappings.AutoMapper.DataObjects;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.Core.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<Student, StudentDTO>();
        }
    }
}
