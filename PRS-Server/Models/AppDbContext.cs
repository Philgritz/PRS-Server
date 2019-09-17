﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Server.Models {



    public class AppDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<User>(en => {

                en.HasIndex(u => u.Username)
                        .HasName("Index-Username")
                        .IsUnique();

            });

            modelBuilder.Entity<Vendor>(en => {

                en.HasIndex(v => v.Code)
                        .HasName("Index-Code")
                        .IsUnique();

            });






        }
    }
}
