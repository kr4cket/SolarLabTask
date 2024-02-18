using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SolarLabTask.Models;

namespace SolarLabTask.DataBase
{
    public partial class WebAppContext : DbContext
    {
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonCategory> PersonCategory { get; set; }
        public virtual DbSet<PersonList> PersonList { get; set; }
        public virtual DbSet<Socials> Socials { get; set; }
        public virtual DbSet<SocialsList> SocialsList { get; set; }
        public virtual DbSet<User> User { get; set; }

        public WebAppContext(DbContextOptions<WebAppContext> options) : base (options) { }

    }
}
