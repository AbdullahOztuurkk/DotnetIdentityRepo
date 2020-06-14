﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CourseWebUI.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        public List<T> MapToSameTypeList<T>(List<T> list)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>();});
            List<T> result = Mapper.Map<List<T>, List<T>>(list);
            return result; 
        }
        public T MapToSameType<T>(T obj)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>(); });
            T result = Mapper.Map<T, T>(obj);
            return result; 
        }
    }
}
