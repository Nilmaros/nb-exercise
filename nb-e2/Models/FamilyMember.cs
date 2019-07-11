using System;
using System.Collections.Generic;
using System.Text;

namespace nb_e2.Models
{
    public class FamilyMember
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Children { get; set; }
        public List<string> Parents { get; set; }
    }
}