using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YDev.Common.Models;

namespace YDev.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RoleTypes> RoleTypes { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<MediaGallery> MediaGalleries { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<StaticPages> StaticPages { get; set; }
        public virtual DbSet<MenuGroup> MenuGroups { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Social> Socials { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<HomeSetting> HomeSettings { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../YDev.Admin/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDBContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new AppDBContext(builder.Options);
        }
    }
}
