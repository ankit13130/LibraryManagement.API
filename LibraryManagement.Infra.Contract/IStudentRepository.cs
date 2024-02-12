using LibraryManagement.Infra.Domain.Models;

namespace LibraryManagement.Infra.Contract;

public interface IStudentRepository
{
    public Task CreateStudentAsync(Student student);
    public Task UpdateStudentAsync(Student student);
    public Task RemoveStudentAsync(Student student);
    public Task<Student> GetStudentAsync(long studentId);
    public Task<IList<Student>> GetAllStudentsAsync();
}
