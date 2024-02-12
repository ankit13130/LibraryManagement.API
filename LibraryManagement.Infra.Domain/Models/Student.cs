namespace LibraryManagement.Infra.Domain.Models;

public class Student : Audit
{
    public long StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email {  get; set; }
    public string Hash { get; set; }
    public string Salt { get; set; }
    public string Roles { get; set; }
}
