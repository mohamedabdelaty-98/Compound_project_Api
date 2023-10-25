﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Component
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual List<UnitComponent>? unitComponents { get; set; }=new List<UnitComponent>();
    }
}
