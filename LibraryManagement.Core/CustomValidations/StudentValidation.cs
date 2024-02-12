using FluentValidation;
using LibraryManagement.Core.Domain.RequestModels;

namespace LibraryManagement.Core.Domain.CustomValidations;

public class StudentValidation : AbstractValidator<StudentRequestModel>
{
    public StudentValidation()
    {
        RuleFor(x=>x.FirstName).NotEqual("string").NotEmpty().Length(4,15);
        RuleFor(x => x.LastName).NotEqual("string").NotEmpty().Length(4, 15);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
