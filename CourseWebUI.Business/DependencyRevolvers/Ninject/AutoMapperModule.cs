using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject.Modules;

namespace CourseWebUI.Business.DependencyRevolvers.Ninject
{
    public class AutoMapperModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(CreateConfiguration().CreateMapper());
        }
        /*Yapılacak olan mapping işlemine göre bir IMapper nesnesi dönüyor.*/
        public MapperConfiguration CreateConfiguration()
        {
            var config=new MapperConfiguration(cfg => 
                cfg.AddProfiles(GetType().Assembly));
            return config;
        }
    }
}
