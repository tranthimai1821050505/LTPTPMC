﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTPTPMC.Models
{
    [Table("Demos")]
    public class Demo
    {
        [Key]
        public string Id { get; set; } 
        public string Name { get; set; }
    }
}