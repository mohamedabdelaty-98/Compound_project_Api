﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public enum Gender
    {
        male,female
    }
    public class User :IdentityUser
    {
        public string Id { get; set; }
        [MaxLength(20)]
        public string FName { get; set; }
        [MaxLength(20)]
        public string LName { get; set; }
        [Column(TypeName ="date")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName ="varchar(10)")]
        public Gender gender{ get; set; }
        [MaxLength(200)]
        public string Address{ get; set; }
        [MaxLength(100)]
        public string Country{ get; set; }
        [ForeignKey("wishlist")]
        public int WishlistID{ get; set; }
        public virtual Wishlist? wishlist { get; set; }
        public virtual List<Review>? reviews { get; set; } = new List<Review>();

    }
}