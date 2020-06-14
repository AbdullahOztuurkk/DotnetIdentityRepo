using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace CourseWebUI.Business.DependencyRevolvers.Ninject
{
    public class InstanceFactory //Bu sınıf webapi'de Handler yapılarındaki instance problemi için oluşturulmuştur.
    {
        public static T GetInstance<T>()
        {
            var kernel=new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
