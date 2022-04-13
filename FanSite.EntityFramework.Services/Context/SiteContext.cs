using FanSite.EntityFramework.Services.Entities;
using FanSiteService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;

namespace FanSiteService.Context
{
    public class SiteContext : DbContext
    {
        private readonly string _connectionString;

        public SiteContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SiteContext(DbContextOptions<SiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserDto> Users { get; set; }
        public virtual DbSet<MediaDto> Media { get; set; }
        public virtual DbSet<MediaSeriesDto> MediaSeries { get; set; }
        public virtual DbSet<RoleDto> Roles { get; set; }
        public virtual DbSet<CommentDto> Comments { get; set; }
        public virtual DbSet<MediaTypeDto> MediaTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            const string connectionStringName = "FANSITE";

            var configuration = new ConfigurationBuilder().
                AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(connectionStringName);

            Console.WriteLine(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CommentDto>()
                .HasKey(nameof(CommentDto.Id), nameof(CommentDto.MediaId), nameof(CommentDto.UserId));

            modelBuilder
                .Entity<CommentDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
