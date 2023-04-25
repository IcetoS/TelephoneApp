using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TelephoneApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TelephoneApp1> TelephoneApp {get; set;}

        public virtual DbSet<TelephoneAppList> TelephoneAppList { get; set;}
    }
}