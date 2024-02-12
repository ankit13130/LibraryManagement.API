using LibraryManagement.Infra.Contract;
using LibraryManagement.Infra.Domain;
using LibraryManagement.Infra.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infra.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly LibraryManagementContext _libraryManagementContext;
    public StudentRepository(LibraryManagementContext libraryManagementContext)
    {
        _libraryManagementContext = libraryManagementContext;
    }

    public async Task CreateStudentAsync(Student student)
    {
        await _libraryManagementContext.AddAsync(student);
        await _libraryManagementContext.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        student.UpdatedOn = DateTime.UtcNow;
        _libraryManagementContext.Update(student);
        await _libraryManagementContext.SaveChangesAsync();
    }

    public async Task RemoveStudentAsync(Student student)
    {
        student.IsActive = false;
        student.DeletedOn = DateTime.Now;
        _libraryManagementContext.Update(student);
        await _libraryManagementContext.SaveChangesAsync();
    }

    public async Task<Student> GetStudentAsync(long studentId)
    {
        return await _libraryManagementContext.Students.FirstOrDefaultAsync(x => x.StudentId == studentId && x.IsActive);
    }

    public async Task<IList<Student>> GetAllStudentsAsync()
    {
        return await _libraryManagementContext.Students.Where(x => x.IsActive).ToListAsync();
    }

    public async Task<Student> GetStudentAsync(string email)
    {
        return await _libraryManagementContext.Students.FirstOrDefaultAsync(x => x.Email == email && x.IsActive);
    }
}