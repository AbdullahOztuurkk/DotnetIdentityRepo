using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace CourseWebUI.Core.CrossCuttingCorners.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid Id, string userName, string Email, DateTime expiration, string[] Roles, bool RememberMe, string FullName)
        {
            var AuthTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, RememberMe, 
                CreateAuthTags(Email, Roles, FullName, Id));
            var encrptTicket = FormsAuthentication.Encrypt(AuthTicket);//Şifrelendi
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encrptTicket));//Standartlara uygun cookie olarak eklendi.
        }

        private static string CreateAuthTags(string email, string[] roles, string fullName, Guid id)
        {
            var _strBuilder = new StringBuilder();
            _strBuilder.Append(email);
            _strBuilder.Append("|");

            for (int i = 0; i < roles.Length; i++)
            {
                _strBuilder.Append(roles[i]);
                if (i < roles.Length)
                    _strBuilder.Append(",");
            }

            _strBuilder.Append(fullName);
            _strBuilder.Append("|");

            _strBuilder.Append(id);
            _strBuilder.Append("|");

            return _strBuilder.ToString();
        }
    }
}
