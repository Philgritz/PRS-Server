﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Server.Models {





    public class AppDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }
    }
}