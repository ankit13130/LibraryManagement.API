using LibraryManagement.Core.Domain.RequestModels;
using LibraryManagement.Core.Domain.ResponseModels;

namespace LibraryManagement.Core.Contract;

public interface IStudentServices
{
    public Task CreateStudentAsync(StudentRequestModel student);
    public Task UpdateStudentAsync(long studentId, StudentRequestModel student);
    public Task RemoveStudentAsync(long studentId);
    public Task<StudentResponseModel> GetStudentAsync(long studentId);
    public Task<IList<StudentResponseModel>> GetAllStudentsAsync();
}
