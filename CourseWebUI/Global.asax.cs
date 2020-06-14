using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using CourseWebUI.Business.DependencyRevolvers.Ninject;
using CourseWebUI.Core.CrossCuttingCorners.Security.Web;
using CourseWebUI.Core.Utilities.Mvc.Infrastucture;

namespace CourseWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(),new AutoMapperModule()));
        }
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, System.EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie == null)/*Böyle bir çerez bulunmamaktadır*/
                {
                    return;
                }

                var encpTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encpTicket))/*Boş gönderilip gönderilmediği kontrol ediliyor*/
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encpTicket);
                SecurityUtilities utilies = new SecurityUtilities();
                var identity = utilies.FormAuthTicketToIdentity(ticket);/* Kimlik oluşturuldu */
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;/*Başka katmanlarda erişim sağlandı*/
            }
            catch
            {
                /*Olası bir hata karşısında önlem alındı.*/ 
            }
        }
    }
}
