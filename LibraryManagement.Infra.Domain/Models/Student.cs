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
    public string ProfileImage {  get; set; }
    protected Student() { }
    public Student(string firstName, string lastName, string email, string hash, string salt, string profileImage)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Hash = hash;
        Salt = salt;
        Roles = "Student";
        ProfileImage = profileImage;
        CreatedOn = DateTime.Now;
        IsActive = true;
    }
}
