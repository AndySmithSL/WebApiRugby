using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Country
    {
        public Country()
        {
            Coach = new HashSet<Coach>();
            Region = new HashSet<Region>();
            TeamCountry = new HashSet<TeamCountry>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int? Population { get; set; }
        public string FlagUrl { get; set; }
        public int? Area { get; set; }
        public int? HighestPoint { get; set; }
        public string HighestPointName { get; set; }
        public string Isocode { get; set; }
        public string Resolution { get; set; }
        public int? Coastline { get; set; }
        public int? LandBoundries { get; set; }

        public ICollection<Coach> Coach { get; set; }
        public ICollection<Region> Region { get; set; }
        public ICollection<TeamCountry> TeamCountry { get; set; }
    }
}
