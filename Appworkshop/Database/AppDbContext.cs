using Appworkshop.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace Appworkshop.Database;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){ }
    
    public DbSet<User> Users { get; set; }
}