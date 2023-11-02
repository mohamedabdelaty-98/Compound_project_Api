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
    public class DTORegisterUser
    {
        [MaxLength(20)]
        public string FName { get; set; }
        [MaxLength(20)]
        public string LName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(10)")]
        public Gender gender { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        public string Email { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        [Compare("Password")]

        public string confirmPasword { get; set; }
    }
}
