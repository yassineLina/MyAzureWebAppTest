using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyWebAppAzure.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons{ get; set; }
   }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public DateTime DateOfBridth { get; set; }
    }
}