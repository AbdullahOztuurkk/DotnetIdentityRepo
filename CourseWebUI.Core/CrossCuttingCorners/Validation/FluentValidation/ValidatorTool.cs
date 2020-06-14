using System;
using FluentValidation;

namespace CourseWebUI.Core.CrossCuttingCorners.Validation.FluentValidation
{
    public static class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, Object entity)
        {
            var result = validator.Validate(entity);
            if(result.Errors.Count>0)
                throw new ValidationException(result.Errors);
        }
    }
}
