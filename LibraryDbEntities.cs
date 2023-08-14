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
        public DbSet<carrer> carrers { get; set; }
        public DbSet<contact> contacts { get; set; }

        public DbSet<Available> Availables { get; set; }

        public DbSet<staff> staffs { get; set; }
  
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet <Videobook> Videobooks { get; set; }

        public DbSet <AudioTable> AudioTables { get; set; }

        public DbSet<Ebook> Ebooks { get; set; }


    }
}