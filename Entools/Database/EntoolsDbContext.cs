using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Database
{
    public class EntoolsDbContext : DbContext
    {
        public EntoolsDbContext()
        {
        }

        public EntoolsDbContext(DbContextOptions<EntoolsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Machines> Machines { get; set; }
        public DbSet<Operations> Operations { get; set; }
        public DbSet<Versions> Versions { get; set; }
        public DbSet<Parts> Parts { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Tools> Tools { get; set; }
        public DbSet<Users> Users{ get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<ToolOperations> ToolOperations { get; set; }
        public DbSet<PartOperations> VersionOperations { get; set; }
        public DbSet<VersionRequest> VersionRequests { get; set; }
        public DbSet<Request> Requests{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Versions>(entity =>
            {
                entity.HasKey(s => s.Id);
            });
        }
    }
}
