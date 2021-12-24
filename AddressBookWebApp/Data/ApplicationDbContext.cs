using AddressBookWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace AddressBookWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AddressBook> AddressBook { get; set; }
    }
}
