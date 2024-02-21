using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SolarLabTask.Models;

namespace SolarLabTask.DataBase
{
    public partial class WebAppContext : DbContext
    {
        public virtual DbSet<PersonImage> PersonImage { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonCategory> PersonCategory { get; set; }
        public virtual DbSet<User> User { get; set; }

        public WebAppContext(DbContextOptions<WebAppContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.ImageId).HasDefaultValue(1);
        }
    }
}
