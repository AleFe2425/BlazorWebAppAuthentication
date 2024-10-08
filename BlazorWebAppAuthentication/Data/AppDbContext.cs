using Microsoft.EntityFrameworkCore;
using BlazorWebAppAuthentication.Models;
using BlazorWebAppAuthentication.Models.Entities;

namespace BlazorWebAppAuthentication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Agregar la tabla UserAccount
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
