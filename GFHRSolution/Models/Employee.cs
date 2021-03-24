using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GFHRSolution.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public int? CountryId { get; set; }
        public int? DesignationId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
