using LibraryManagement.Core.Domain.RequestModels;

namespace LibraryManagement.Core.Contract;

public interface IValidationServices
{
    public Task<string> ValidateLoginAsync(LoginRequestModel loginRequestModel);
    public Task ValidateSignupAsync(StudentRequestModel studentRequestModel);
}
