﻿using System;
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

        //private string _connection = string.Empty;
        // TODO Заменить подключение к БД на другое (через файл конфигурации) 
        public WebAppContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}