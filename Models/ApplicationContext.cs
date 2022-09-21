using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        //reference out model classes
        // <always referrs to a class or type> can get and set data to it. See below.
        public DbSet<Baker> Bakers {get; set;}
        // We will now begin migration: 2 steps: set up a migration, then execute migration.
        // Step 1, set up migration
            // dotnet ef migrations add CreateBakerTable
        // Step 2, execute!
            // dotnet ef database update
        // IF YOU CANGE YOUR MODEL CLASS like add hatColor to your bakers,
        // youll have to do another migration. This will translate it to the table.

        public DbSet<Bread> Breads {get; set;}
    }
}