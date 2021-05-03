using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTPTPMC.Models
{
    public class Student : Person
    {
        public string Address { get; set; }
        public string University { get; set; }
    }
}