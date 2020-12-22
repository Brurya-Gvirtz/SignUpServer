using SignUpProject.Entities;
using System;
using System.Data.Entity;

namespace SignUpProject.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
      
    }
}