using System;
using System.Web.Security;

namespace CourseWebUI.Core.CrossCuttingCorners.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormAuthTicketToIdentity(FormsAuthenticationTicket _ticket)
        {
            var _identity = new Identity
            {
                AuthenticationType = setAuthType(),
                FullName = setFullName(_ticket),
                IsAuthenticated = setIsAuthenticated(),
                MailAddress = setEmail(_ticket),
                Name = setName(_ticket),
                Roles = setRoles(_ticket),
                Id = setId(_ticket)
            };
            return _identity;
        }

        private static string setAuthType()
        {
            return "Forms";
        }

        private static string setFullName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private static bool setIsAuthenticated()
        {
            return true;
        }

        private static string setName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private static string setEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private static string[] setRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private static Guid setId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
