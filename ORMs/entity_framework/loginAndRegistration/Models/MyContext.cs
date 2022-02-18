using Microsoft.EntityFrameworkCore;
// Dont forget to change your namespace to the correct namespace
namespace loginAndRegistration.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // Set up whatever models are going to be in your database
        public DbSet<User> Users { get; set; }
        // More models go here
    }
}