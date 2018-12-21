using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Stadium
    {
        public Stadium()
        {
            Match = new HashSet<Match>();
        }

        public int StadiumId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int? Capacity { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public City City { get; set; }
        public ICollection<Match> Match { get; set; }
    }
}
