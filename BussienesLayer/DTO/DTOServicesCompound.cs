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
    public class DTOServicesCompound
    {
        public int Id { get; set; }

        public string Compound_Name { get; set; }
        public string Service_Name { get; set; }

        public string Service_Description { get; set; }


        // public Compound? compound { get; set; }
        //public int ServiceId { get; set; }

       // public  DTOAmmenities? services { get; set; }

    }
}
