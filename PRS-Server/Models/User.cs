﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRS_Server.Models {
    public class User {

        public User() {}

        public int Id { get; set; }  //auto designated as pk
        [Required]  
        [StringLength(30)] 
        public string Username { get; set; } //must be unique see onmodelcreating method
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public bool IsReviewer { get; set; } = false;
        public bool IsAdmin { get; set; } = false;

        

    }
}
