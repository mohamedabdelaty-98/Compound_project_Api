using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compound_project.DTO;

namespace BussienesLayer.DTO
{
    public class DTOServicesUnit
    {
        public int Id { get; set; }
        public int Unit_Name { get; set; }
        public string Service_Name { get; set; }

        public string Service_Description { get; set; }




        // public int UnitId { get; set; }
        // public virtual DTOUnit? unit { get; set; }
        //[ForeignKey("service")]

        //public int ServiceId { get; set; }
        //public virtual Service? service { get; set; }
        //public DTOService? service { get; set; }
    }
}
