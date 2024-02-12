namespace LibraryManagement.Infra.Domain.Models;

public class Student : Audit
{
    public long StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
