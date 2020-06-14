using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseWebUI.Business.Abstract;
using CourseWebUI.Core.CrossCuttingCorners.Security.Web;

namespace CourseWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IStudentService _studentService;

        public AccountController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public string Login(string UserName,string Password)
        {
            var student = _studentService.GetByEmailAndPassword(UserName,Password);
            if (student != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    userName:student.MailAddress.Substring(0,student.MailAddress.IndexOf('@')),
                    Email:student.MailAddress,
                    expiration:DateTime.Now.AddDays(15),
                    _studentService.GetStudentRoles(student).Select(z=>z.RoleName).ToArray(),
                    false,
                    FullName:student.FullName
                );
            }

            return "User is not authenticated !";
        }
    }
}