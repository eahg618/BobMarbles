using Microsoft.EntityFrameworkCore;

namespace BobMarbles.Models
{
    public class AppMainContext: DbContext
    {
        private readonly DbContextOptions _options;
        private string[] args;
        public AppMainContext()
        {

        }
        public AppMainContext(DbContextOptions<AppMainContext> options):base(options)
        {
            _options = options;
        }

        public DbSet<Marble> Marbles { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)

            {
                var builder = WebApplication.CreateBuilder(args);
                options.UseSqlServer(builder.Configuration.GetConnectionString("BobMarblesConnection"));

            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }



}
