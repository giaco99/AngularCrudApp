using Microsoft.EntityFrameworkCore;
using PluServiceCoreApi.Models;

namespace PluServiceCoreApi.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
