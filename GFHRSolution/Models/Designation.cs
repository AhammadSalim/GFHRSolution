using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GFHRSolution.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Designation1 { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
