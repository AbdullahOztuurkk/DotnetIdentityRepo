using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CourseWebUI.Business.Abstract;
using CourseWebUI.Business.DependencyRevolvers.Ninject;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.WebApi.MessageHandlers
{
    public class AuthorizationHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = request.Headers.GetValues("Authorization").FirstOrDefault();//Authorization adi altinda bir token bekliyoruz.
            if (token != null)
            {
                byte[] data = Convert.FromBase64String(token);
                string decodedString = Encoding.UTF8.GetString(data);
                string[] TokenValues = decodedString.Split(':');//Abdullah@gmail.com:1234 gibi bir format olacak.

                IStudentService _studentService = InstanceFactory.GetInstance<IStudentService>();

                Student _student = _studentService.GetByEmailAndPassword(TokenValues[0], TokenValues[1]);

                if (_student!=null)/*Böyle bir öğrenci varsa*/
                {
                    var principal=new GenericPrincipal(new GenericIdentity(TokenValues[0]),
                        _studentService.GetStudentRoles(_student).Select(z=>z.RoleName).ToArray());/*Rolleri dizi olarak aldık*/
                    Thread.CurrentPrincipal = principal;//backend tarafinda oluşturduk
                    HttpContext.Current.User = principal;//mvc için oluşturduk.
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}