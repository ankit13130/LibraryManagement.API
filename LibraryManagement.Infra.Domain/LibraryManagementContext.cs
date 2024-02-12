using LibraryManagement.Infra.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infra.Domain;

public class LibraryManagementContext : DbContext
{
    public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options) : base(options) { }
    public DbSet<Student> Students { get; set; }
}
