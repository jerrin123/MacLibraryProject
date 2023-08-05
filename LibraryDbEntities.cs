using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MacLibraryProject.Models;
namespace MacLibraryProject
{
    public class LibraryDbEntities : DbContext
    {
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}