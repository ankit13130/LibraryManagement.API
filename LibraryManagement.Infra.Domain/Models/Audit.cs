namespace LibraryManagement.Infra.Domain.Models;

public class Audit
{
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public bool IsActive { get; set; } = true;
}
