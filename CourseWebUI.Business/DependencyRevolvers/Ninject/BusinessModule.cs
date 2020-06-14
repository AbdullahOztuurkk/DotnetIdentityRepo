using System.Data.Entity;
using CourseWebUI.Business.Abstract;
using CourseWebUI.Business.Concrete;
using CourseWebUI.DataAccess.Abstract;
using CourseWebUI.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace CourseWebUI.Business.DependencyRevolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentDal>().To<EfStudentDal>().InSingletonScope();
            Bind<ICourseDal>().To<EfCourseDal>().InSingletonScope();

            Bind<ICourseService>().To<CourseManager>().InSingletonScope();
            Bind<IStudentService>().To<StudentManager>().InSingletonScope();

            Bind<DbContext>().To<CourseContext>().InSingletonScope();

        }
    }
}
