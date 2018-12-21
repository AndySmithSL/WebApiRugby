using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Coach
    {
        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public int? CountryId { get; set; }

        public Country Country { get; set; }
        public Team Team { get; set; }
    }
}
