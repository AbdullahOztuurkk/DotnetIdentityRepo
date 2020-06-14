using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace CourseWebUI.Core.Aspects.Postsharp.Security
{
    [Serializable]
    public class SecuredOperation:OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] userRoles = Roles.Split(',');
            bool is_authorizated = false;
            foreach (var userRole in userRoles)
            {
                if (Thread.CurrentPrincipal.IsInRole(userRole))
                    is_authorizated = true;
            }
            if(is_authorizated==false)
                throw new SecurityException("You are not authorizated.");
        }
    }
}
