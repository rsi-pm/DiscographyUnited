using System.IO;
using DiscographyUnited.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiscographyUnited.Data
{
    public class DiscographyUnitedContext : DbContext
    {
        public DiscographyUnitedContext()
        {
        }

        public DiscographyUnitedContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AwardEntity> Award { get; set; }
        public virtual DbSet<GenreEntity> Genre { get; set; }
        public virtual DbSet<PersonEntity> Person { get; set; }
        public virtual DbSet<RecordEntity> Record { get; set; }
        public virtual DbSet<StyleEntity> Style { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=DiscographyUnitedDB;");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        var connectionString = configuration.GetConnectionString("DiscographyUnitedDB");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
    }
}
