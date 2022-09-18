using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EasyNotes.Data.EntityFramework
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            dbContextBuilder.UseSqlServer(connectionString);

            return new AppDbContext(dbContextBuilder.Options);
        }   
    }
}
