using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class City
    {
        public City()
        {
            Player = new HashSet<Player>();
            School = new HashSet<School>();
            Stadium = new HashSet<Stadium>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int? Population { get; set; }
        public bool IsCapital { get; set; }
        public int RegionId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public Region Region { get; set; }
        public ICollection<Player> Player { get; set; }
        public ICollection<School> School { get; set; }
        public ICollection<Stadium> Stadium { get; set; }
    }
}
