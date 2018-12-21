using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class TeamCountry
    {
        public int TeamCountryId { get; set; }
        public int TeamId { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public Team Team { get; set; }
    }
}
