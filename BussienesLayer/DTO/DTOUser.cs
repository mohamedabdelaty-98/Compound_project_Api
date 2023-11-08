using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO
{
    public class DTOUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int? WishlistID { get; set; }
    }
}
