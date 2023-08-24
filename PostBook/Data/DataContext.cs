using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostBook.Domain;

namespace PostBook.Data
{
    public class DataContext: IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts  { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
