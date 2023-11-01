﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO.LandmarkDTO
{
   public class LandmarkDTO
   {

      public int? Id { get; set; }
      public string? Name { get; set; }
      public List<string>? LandMarksCompoundDescription { get; set; } = new();
   }
}
