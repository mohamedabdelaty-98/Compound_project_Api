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
    public class DTOServices
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? IConName { get; set; }

    }
}
