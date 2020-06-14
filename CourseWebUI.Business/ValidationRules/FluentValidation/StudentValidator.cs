using CourseWebUI.Entities.Concrete;
using FluentValidation;

namespace CourseWebUI.Business.ValidationRules.FluentValidation
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(z => z.FullName).NotEmpty();
            RuleFor(z => z.MailAddress).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.PhoneNumber).NotEmpty();
        }
    }
}
