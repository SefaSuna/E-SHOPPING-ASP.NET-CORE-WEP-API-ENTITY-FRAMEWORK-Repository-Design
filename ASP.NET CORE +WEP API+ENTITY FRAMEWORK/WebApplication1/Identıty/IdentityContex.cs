using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Identıty
{
    public class IdentityContex:IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-ALKJBUB;initial catalog=Web;integrated Security=true");
        }
        public IdentityContex(DbContextOptions<IdentityContex> options) : base(options)
        {

        }
    }
}
