using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Region
    {
        public Region()
        {
            City = new HashSet<City>();
        }

        public int RegionId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<City> City { get; set; }
    }
}
