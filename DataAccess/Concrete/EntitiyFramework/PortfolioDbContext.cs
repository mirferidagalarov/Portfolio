﻿using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class PortfolioDbContext : IdentityDbContext<User, Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Localhost;database=Portfolio;integrated security=true;");

            //optionsBuilder
            //    .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Portfoli> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<AboutSkill> AboutSkills { get; set; }
        public DbSet<WorkCategory> WorkCategories { get; set; }
        public DbSet<Service> Services { get; set; }

      
    }
}
