using LibraryManagement.Core.Domain.RequestModels;
using LibraryManagement.Infra.Domain.Models;

namespace LibraryManagement.Core.Builder;

public class StudentBuilder
{
    public static Student Build(StudentRequestModel studentRequestModel, string Hash, string Salt, string profilePath)
    {
        return new Student(studentRequestModel.FirstName,studentRequestModel.LastName,studentRequestModel.Email, Hash, Salt,profilePath);
    }
}
