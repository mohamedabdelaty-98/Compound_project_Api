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
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UnitId { get; set; }
        public int? ServiceId { get; set; }

    }
}
