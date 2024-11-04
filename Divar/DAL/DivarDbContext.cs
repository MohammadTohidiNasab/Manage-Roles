﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Divar.DAL
{
    public class DivarDbContext : IdentityDbContext<User>
    {
        public DivarDbContext(DbContextOptions<DivarDbContext> options) : base(options) { }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }



        ////make Cascade Delete for Advertisement
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Advertisement>()
        //        .HasOne(a => a.User)
        //        .WithMany(u => u.Advertisements)
        //        .HasForeignKey(a => a.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // make Email uniqe 
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>()
        //        .HasIndex(u => u.Email)
        //        .IsUnique();
        //}
    }
}

