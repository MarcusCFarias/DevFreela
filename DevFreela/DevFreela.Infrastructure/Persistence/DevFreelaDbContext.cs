using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using System.Reflection;
using DevFreela.Infrastructure.Configurations;

namespace DevFreela.Infrastructure.Persistance
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
    }
}

