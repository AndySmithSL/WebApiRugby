using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class School
    {
        public School()
        {
            Player = new HashSet<Player>();
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int? Founded { get; set; }
        public short Type { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public City City { get; set; }
        public SchoolType TypeNavigation { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}
