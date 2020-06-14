using System;
using System.Security.Principal;

namespace CourseWebUI.Core.CrossCuttingCorners.Security
{
    public class Identity:IIdentity
    {
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string MailAddress { get; set; }
        public string[] Roles { get; set; }
    }
}
