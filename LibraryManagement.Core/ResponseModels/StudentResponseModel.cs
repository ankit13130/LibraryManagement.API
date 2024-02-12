namespace LibraryManagement.Core.Domain.ResponseModels;

public record StudentResponseModel
{
    public long StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
