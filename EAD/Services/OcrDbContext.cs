using EAD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EAD.Services
{
    public class OcrDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public OcrDbContext(DbContextOptions<OcrDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<FtpConfiguration> FtpConfigurations { get; set; }

        public DbSet<FtpResult> FtpResults { get; set; }

        public DbSet<OcrConfiguration> OcrConfigurations { get; set; }

        public void Initialize()
        {
            if (bool.Parse(_configuration["Database:RecreateDatabase"]))
            {
                Database.EnsureDeleted();
            }

            if (bool.Parse(_configuration["Database:RunMigrations"]))
            {
                Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FtpResult>().HasIndex(x => x.Date);
            modelBuilder.Entity<FtpResult>().HasIndex(x => x.FilePath);
            modelBuilder.Entity<FtpResult>().HasIndex(x => x.Status);

            modelBuilder.Entity<OcrConfiguration>().HasIndex(x => x.Name);
            modelBuilder.Entity<OcrConfiguration>().HasIndex(x => x.CreatedById);
            modelBuilder.Entity<OcrConfiguration>().HasIndex(x => x.UpdatedById);

            base.OnModelCreating(modelBuilder);
        }
    }
}