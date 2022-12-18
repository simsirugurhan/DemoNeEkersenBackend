using DemoNeEkersen.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeEkersen.Data
{
    public class PostgreSqlDemoDbContext : DbContext
    {
        public PostgreSqlDemoDbContext(DbContextOptions<PostgreSqlDemoDbContext> options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreSqlDemoDbContext).Assembly);
        }
    }
}
