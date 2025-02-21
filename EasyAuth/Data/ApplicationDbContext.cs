using EasyAuth.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyAuth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<TokenModel> Tokens { get; set; }
    }
    
}
