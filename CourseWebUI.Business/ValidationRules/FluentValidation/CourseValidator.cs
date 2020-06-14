using CourseWebUI.Entities.Concrete;
using FluentValidation;

namespace CourseWebUI.Business.ValidationRules.FluentValidation
{
    public class CourseValidator:AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(n => n.CourseName).NotEmpty();
            RuleFor(m => m.Description).NotEmpty();
        }
    }
}
