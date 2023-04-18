using Microsoft.EntityFrameworkCore;
using Scrutz.Model;
using System.Xml;

namespace Scrutz.Data
{
    public class ScrutzContext : DbContext
    {
        public ScrutzContext(DbContextOptions<ScrutzContext> options) : base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>().HasKey(p => p.Id);
            modelBuilder.Entity<Campaign>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Campaign>()
                .Property(e => e.LinkedKeywords)
                .HasMaxLength(300)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .ToArray()
                );
        }

    }
}
