using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurfClub.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace SurfClub.Models
{
    public class SurfClubDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public SurfClubDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   Nickname = "TestUser",
                   Password = "TestPassword",
                   Photo = new Guid("498d7e21-cb9b-43a6-9e5b-37fcb41e273f")
               });
        }
    }
}
