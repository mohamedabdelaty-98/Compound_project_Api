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
     public class DTOServicesBuilding
    {
        public int Id { get; set; }
        
        //public  DTOBuilding? building { get; set; }
       // public   DTOAmmenities? service { get; set; }
    }
}
