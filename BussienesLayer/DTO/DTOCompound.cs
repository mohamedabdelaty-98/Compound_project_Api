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
    public class DTOCompound
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }     
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime? DateAdded { get; set; }
        public string File { get; set; }
        public double Street_area { get; set; }
        public double GreenArea { get; set; }
        public double BuildingArea { get; set; }
        public string Location { get; set; }
        public int CompoundId { get; set; }
        public  List<DTOBuilding>? buildings { get; set; } = new List<DTOBuilding>();


    }
}
