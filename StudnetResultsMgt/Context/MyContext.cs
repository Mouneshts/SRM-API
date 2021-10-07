using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SRM_API.Context
{
    public class MyContext :DbContext
    {
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MyDBConn");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Branch> branch { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Result> results { get; set; }

        public DbSet<Semester> semesters { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subjects> subjects { get; set; }

    }
}
